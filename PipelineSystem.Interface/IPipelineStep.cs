using System;

namespace PipelineSystem.Interface;

public interface IPipelineStep<TInput, TOutput> : IPipeline
{
    Task<TOutput> ProcessAsync(TInput input, CancellationToken cancellationToken);

}

public interface IPipeline
{
}