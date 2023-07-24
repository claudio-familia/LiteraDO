using LiteraDO.DataAccess.Repositories;
using LiteraDO.DataAccess.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LiteraDO.DataAccess.Configuration
{
    public static partial class RepositoriesConfiguration
    {
        public static void AddRespositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LiteraDODBContext>(m =>
            {
                m.UseMySQL(configuration.GetConnectionString("LiteraDO"));
            });

            services.AddScoped<IDataRepositoryFactory, DataRepositoryFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient(typeof(IDataRepository<>), typeof(Repository<>));
        }
    }
}
