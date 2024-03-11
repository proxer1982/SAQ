using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SAQ.Infrastructure.Persistence.Context;
using SAQ.Infrastructure.Persistence.Interfaces;
using SAQ.Infrastructure.Persistence.Repositories;

namespace SAQ.Infrastructure.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var assembly = typeof(SAQContext).Assembly.FullName;

            services.AddDbContext<SAQContext>(
                 options => options.UseNpgsql(
                      config.GetConnectionString("SAQConnectionPs"),
                      b => b.MigrationsAssembly(assembly)
                      ),
                 ServiceLifetime.Transient);


            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;

        }
    }
}
