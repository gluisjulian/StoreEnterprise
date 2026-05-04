using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SE.Identidade.API;

namespace SE.Identidade.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Aqui indicamos que a classe Startup será utilizada
                    webBuilder.UseStartup<Startup>();
                });
    }
}
