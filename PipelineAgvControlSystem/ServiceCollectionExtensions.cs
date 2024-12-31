using System;
using System.Reflection;
using AgvControlSyetem.Entity.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace PipelineAgvControlSystem;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddLogic(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        // 找到所有实现了 IBaseLogic 接口的类
        var logicTypes = assembly.GetTypes()
                                 .Where(t => t.IsClass && !t.IsAbstract && typeof(ILogic).IsAssignableFrom(t));

        foreach (var type in logicTypes)
        {
            services.AddScoped(type); // 注册类本身
        }

        return services;
    }

   
}
