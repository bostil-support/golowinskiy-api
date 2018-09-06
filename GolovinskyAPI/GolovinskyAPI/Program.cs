using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace GolovinskyAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            //.UseKestrel(o =>
            //{
            //    o.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(30);
            //})
            .UseIISIntegration()
            .UseStartup<Startup>()
                .Build();
    }
}
