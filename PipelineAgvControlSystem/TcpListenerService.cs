using System.Net;
using System.Net.Sockets;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PipelineAgvControlSystem.Logic;

namespace PipelineAgvControlSystem;

public class TcpListenerService(Context context, ILogger<TcpListenerService> logger, BasePathLogic basePathLogic) : IHostedService
{
    Task TcpListenerTask { get; set; }
    TcpListener tcpListener { get; set; }

    public delegate Task StepFinishEventHandler(byte[] data);

    public event StepFinishEventHandler StepFinish;

    CancellationTokenSource _cts;
    public Task StartAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation("Start TcpListener Service..."); ;
        logger.LogInformation("Init Context..."); ;
        if (!context.InitContext())
        {
            logger.LogWarning("Init Context Fail");
            return Task.FromResult(false);
        }
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        TcpListenerTask = Task.Run(() => StartTcpListeninigAsync(_cts.Token), _cts.Token);
        return Task.CompletedTask;
    }

    private async Task StartTcpListeninigAsync(CancellationToken token)
    {
        try
        {
            var ServerIpAddress = IPAddress.Parse(context.SystemConfigDict["ServerIpAddress"]);
            var ServerPort = int.Parse(context.SystemConfigDict["TcpServerPort"]);
            tcpListener = new TcpListener(ServerIpAddress, ServerPort);
            tcpListener.Start();
            logger.LogInformation($"Tcp Listener started ,IPAddress:{ServerIpAddress},Port:{ServerPort}");
            while (!token.IsCancellationRequested)
            {
                try
                {

                    var socket = await tcpListener.AcceptSocketAsync(token);
                    var remoteEndPoint = socket.RemoteEndPoint as IPEndPoint;

                    if (remoteEndPoint == null)
                    {
                        logger.LogWarning("RemoteEndPoint is null for the connected socket.");
                        return;
                    }

                    var remoteAddress = remoteEndPoint.Address.ToString();
                    var matchedAgv = context.BasicAgvDict.FirstOrDefault(entry => entry.Value.agv_ipaddress == remoteAddress);

                    if (!string.IsNullOrEmpty(matchedAgv.Key))
                    {
                        logger.LogInformation($"{matchedAgv.Key} connected at {remoteEndPoint}");
                        if (context.AgvSocketDict[matchedAgv.Key] != null)
                            context.AgvSocketDict[matchedAgv.Key] = socket;
                        else
                            context.AgvSocketDict.TryAdd(matchedAgv.Key, socket);
                        Task clientTask = Task.Run(() => TcpReciveAsync(socket, token));
                    }
                    else
                    {
                        logger.LogWarning($"Unknown device connected from {remoteEndPoint}");
                    }
                }
                catch (OperationCanceledException)
                {
                    logger.LogInformation("TCP Listener cancellation requested.");
                    break;
                }
                catch (Exception ex)
                {
                    logger.LogError($"Error accepting client: {ex.Message}");
                }
            }
        }
        finally
        {
            logger.LogInformation("TCP Listener stopped.");
        }
    }

    private async Task TcpReciveAsync(Socket socket, CancellationToken token)
    {
        socket.ReceiveBufferSize = 1024;
        IPEndPoint remoteEndPoint = (IPEndPoint)socket.RemoteEndPoint;
        string clientAddress = remoteEndPoint.Address.ToString();
        string clientEndpoint = socket.RemoteEndPoint.ToString();
        byte[] buffer = new byte[39];

        try
        {
            while (!token.IsCancellationRequested)
            {
                var receiveTask = socket.ReceiveAsync(buffer, SocketFlags.None);
                int bytesRead = await receiveTask;

                if (bytesRead == 0)
                {
                    logger.LogInformation($"Client {clientEndpoint} disconnected.");
                    break;
                }
                if (bytesRead == 39 && StepFinish != null)
                {
                    StepFinish(buffer);
                }
                else
                {
                    logger.LogWarning($"Unexpected data length from {clientEndpoint}: {bytesRead} bytes.");
                }
            }
        }
        catch (SocketException ex)
        {
            logger.LogError($"Socket error from {clientEndpoint}: {ex.Message}");
        }
        catch (Exception ex)
        {
            logger.LogError($"Unexpected error from {clientEndpoint}: {ex.Message}");
        }
        finally
        {
            socket.Close();
            socket.Dispose();
            logger.LogInformation($"Connection to {clientEndpoint} closed.");
        }
    }
    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Stop Main Service...");
        _cts.Cancel();
        tcpListener?.Stop();
        return TcpListenerTask ?? Task.CompletedTask;
    }
}
