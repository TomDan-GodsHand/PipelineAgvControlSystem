using System;
using Azure;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PipelineAgvControlSystem.Logic;

namespace PipelineAgvControlSystem;

public class MainService(ILogger<MainService> logger, BasePathLogic basePathLogic) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {

        var a = basePathLogic.FindAll();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
