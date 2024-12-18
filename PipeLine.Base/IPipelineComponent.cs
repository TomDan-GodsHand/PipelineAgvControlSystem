using System;

namespace PipeLine.Base;

public interface IPipelineComponent
{
    Task ExecuteAsync(IPipelineContext context, Func<Task> next);
}
