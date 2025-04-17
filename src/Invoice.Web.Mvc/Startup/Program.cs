using Abp.AspNetCore.Dependency;
using Abp.Dependency;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace Invoice.Web.Startup;

public class Program
{
    public static void Main(string[] args)
    {
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        CreateHostBuilder(args).Build().Run();
    }

    internal static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseCastleWindsor(IocManager.Instance.IocContainer);
}
