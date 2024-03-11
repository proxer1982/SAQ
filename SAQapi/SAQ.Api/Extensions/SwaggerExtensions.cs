using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace SAQ.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            var openApi = new OpenApiInfo
            {
                Title = "SAQ API",
                Version = "v1",
                Description = "Calificador de habilidades API 2024",
                TermsOfService = new Uri("http://opensource.org/linceces/WIT"),
                Contact = new OpenApiContact
                {
                    Name = "Satrack",
                    Email = "juan.zorro@satrck.com",
                    Url = new Uri("https://satrack.com")
                },
                License = new OpenApiLicense
                {
                    Name= "Use under LICX",
                    Url = new Uri("http://opensource.org/linceces/WIT")
                }
            };

            services.AddSwaggerGen(x =>
            {
                openApi.Version = "v1";
                x.SwaggerDoc("v1", openApi);

                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Jwt authentication",
                    Description = "Jwt bearer Token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                x.AddSecurityDefinition(securitySchema.Reference.Id, securitySchema);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new string[] { } }
                });
            });

            return services;
        }
    }
}
