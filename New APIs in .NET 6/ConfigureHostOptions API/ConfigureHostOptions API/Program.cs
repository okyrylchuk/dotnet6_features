// https://twitter.com/okyrylchuk/status/1454499505387212800

using Microsoft.Extensions.Hosting;
using System;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureHostOptions(o =>
            {
                o.ShutdownTimeout = TimeSpan.FromMinutes(10);
            });
}

