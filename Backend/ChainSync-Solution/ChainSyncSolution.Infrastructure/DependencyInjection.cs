using ChainSyncSolution.Application.Interfaces.Authentication;
using ChainSyncSolution.Application.Interfaces.ErrorControl;
using ChainSyncSolution.Application.Interfaces.IRepository;
using ChainSyncSolution.Application.Interfaces.Persistence;
using ChainSyncSolution.Application.Interfaces.Providers;
using ChainSyncSolution.Infrastructure.Common.Authentication;
using ChainSyncSolution.Infrastructure.Common.ErrorControl;
using ChainSyncSolution.Infrastructure.Common.Persistence;
using ChainSyncSolution.Infrastructure.Common.Providers;
using ChainSyncSolution.Infrastructure.Common.Repository;
using ChainSyncSolution.Infrastructure.Connection;
using ChainSyncSolution.Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChainSyncSolution.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       ConfigurationManager configuration)
    {
        services.AddAuth(configuration);

        services.AddDbStorage(configuration);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IExceptionConfiguration, ExceptionConfiguration>();

        return services;
    }

    public static IServiceCollection AddAuth(
       this IServiceCollection services,
       ConfigurationManager configuration)
    {
        var JwtSettings = new JwtSettings();

        configuration.Bind(JwtSettings.SectionName, JwtSettings);

        services.AddSingleton(Options.Create(JwtSettings));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = JwtSettings.Issuer,
                ValidAudience = JwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(JwtSettings.Secret))
            });

        return services;
    }

    public static IServiceCollection AddDbStorage(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var defaultConnectionString = configuration.GetConnectionString(ConnectionSettings.ConnectionStrings);

        services.AddDbContext<ChainSyncDbContext>(option => option.UseSqlServer(defaultConnectionString));

        return services;
    }
}
