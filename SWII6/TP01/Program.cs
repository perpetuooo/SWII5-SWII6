using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TP01
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Test testes = new Test();
            testes.TestBookMethods();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
//Pedro H Perpétuo & Igor Benites