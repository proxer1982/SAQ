using FluentValidation.AspNetCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SAQ.Application.Interfaces;
using SAQ.Application.Services;

using System.Reflection;

namespace SAQ.Application.Extensions
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjectionApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton(config);

            services.AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies().Where(p => !p.IsDynamic));
            });

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IDbApplication, DbApplication>();

            services.AddScoped<IRoleApplication, RoleApplication>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<IMenuApplication, MenuApplication>();
            services.AddScoped<IPositionApplication, PositionApplication>();

            return services;
        }
    }
}


