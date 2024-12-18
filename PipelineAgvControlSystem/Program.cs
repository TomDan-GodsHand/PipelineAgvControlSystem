
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace PipelineAgvControlSystem;

public class Program
{
    static async void Main(string[] args)
    {
        try
        {
            HostApplicationBuilder builder = new HostApplicationBuilder(args);

            var service = builder.Services;
            service.AddLogging();

            using IHost host = builder.Build();
            await host.RunAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
