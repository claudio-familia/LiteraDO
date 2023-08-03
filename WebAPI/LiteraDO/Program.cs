using LiteraDO.DataAccess;
using LiteraDO.DataAccess.Configuration;
using Microsoft.EntityFrameworkCore;

namespace LiteraDO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LiteraDODBContext>();
                dbContext.Database.Migrate();
                DataSeeder.SeedData(dbContext);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
