using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Helpdesk.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((ctx, builder) =>
                    builder.AddHelpdeskConfiguration(ctx.HostingEnvironment.EnvironmentName, args)
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}