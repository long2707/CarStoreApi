



using CarStoreApi.Application.Common.Interface;
using CarStoreApi.Application.Interfaces;
using CarStoreApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using CarStoreApi.Infrastructure.Authentication;
using CarStoreApi.Infrastructure.Repositorries;
using CarStoreApi.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using CarStoreApi.Application.Services;
using CarStoreApi.Application.Services;
using CarStoreApi.Infrastructure.AI;
using CarStoreApi.Application.Common.Interface.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using CarStoreApi.Infrastructure.Mail;

namespace CarStoreApi.Infrastructure
{
    public static class DenependencyInjection
    {


        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CarStoreDatabase")));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
            services.Configure<MailSettings>(configuration.GetSection(MailSettings.SectionName));
            services.Configure<AISettings>(configuration.GetSection(AISettings.SectionName));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMailService, MailService>();
          //  services.AddHttpClient<IAIService, AIService>();


            return services;
        }

    }
}
