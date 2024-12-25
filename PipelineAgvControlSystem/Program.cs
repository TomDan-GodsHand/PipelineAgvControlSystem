using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SqlSugar;

namespace PipelineAgvControlSystem;

public class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            HostApplicationBuilder builder = new HostApplicationBuilder(args);
            var service = builder.Services;

            // Add log service to host
            service.AddLogging();

            #region  注入 sqlsugar 服务

            service.AddScoped<ISqlSugarClient>(s =>
            {
                SqlSugarClient sqlSugar = new(new ConnectionConfig()
                {
                    DbType = SqlSugar.DbType.MySql,
#if DEBUG
                    ConnectionString = "server=192.168.30.253;Database=wanjiang_db;Uid=root;Pwd=GoodJob8899123;",
#elif RELEASE
                     ConnectionString = "server=127.0.0.1;Database=trx_agv_db;Uid=root;Pwd=GoodJob8899123;",
#endif
                    IsAutoCloseConnection = true,
                },
                db =>
                {
                    //每次上下文都会执行
                    var logger = s.GetService<ILogger<SqlSugarClient>>();
                    db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        logger.LogInformation(sql, pars);
                    };
                });
                return sqlSugar;

            });
            #endregion


            // Add Logic Class to host
            service.AddLogic();

            // Add core service to host
            service.AddHostedService<MainService>();

            // build the host
            using IHost host = builder.Build();

            // Await run host
            await host.RunAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}
