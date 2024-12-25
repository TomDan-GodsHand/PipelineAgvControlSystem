using System;
using System.Net;
using System.Net.Sockets;
using Azure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PipelineAgvControlSystem.Logic;

namespace PipelineAgvControlSystem;

public class MainService(Context context, ILogger<MainService> logger, BasePathLogic basePathLogic) : IHostedService
{
    Task TcpListernerTask { get; set; }
    TcpListener tcpListener { get; set; }
    CancellationTokenSource _cts;
    public Task StartAsync(CancellationToken cancellationToken)
    {

        logger.LogInformation("Start Main Service..."); ;
        logger.LogInformation("Init Context..."); ;
        if (!context.InitContext())
        {
            logger.LogWarning("Init Context Fail");
            return Task.FromResult(false);
        }
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        TcpListernerTask = Task.Run(() => StartTcpListeninigAsync(_cts.Token), _cts.Token);
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
                    var client = await tcpListener.AcceptTcpClientAsync(token);
                    var remoteEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    foreach (var (agvcode, enty) in context.BasicAgvDict)
                    {
                        if (enty.agv_ipaddress == remoteEndPoint.Address.ToString())
                        {

                        }
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

    public Task StopAsync(CancellationToken cancellationToken)
    {
        logger.LogInformation($"Stop Main Service...");
        _cts.Cancel();
        tcpListener?.Stop();
        return TcpListernerTask ?? Task.CompletedTask;
    }
}
