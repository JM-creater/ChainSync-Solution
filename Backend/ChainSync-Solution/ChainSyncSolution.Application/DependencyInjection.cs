using ChainSyncSolution.Application.Common.Behavior;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using MediatR;
using ChainSyncSolution.Application.Common.Mapping;
using ChainSyncSolution.Application.Assets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;

namespace ChainSyncSolution.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(RegisterMapper));

        services.AddMediatR(Assembly.GetExecutingAssembly());

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(
            typeof(IPipelineBehavior<,>),
            typeof(ValidationBehavior<,>));

        services.AddHealthChecks();

        return services;
    }

    public static void ConfigureFigures(this IApplicationBuilder app, IConfiguration configuration)
    {
        var serviceProvider = app.ApplicationServices;
        var imagePathOptions = serviceProvider.GetRequiredService<IOptions<AssetImageOptions>>().Value;
        var env = serviceProvider.GetService<IWebHostEnvironment>();

        var imageFolderPath = Path.Combine(env.ContentRootPath, imagePathOptions.PathImages);

        if (!Directory.Exists(imageFolderPath))
        {
            Directory.CreateDirectory(imageFolderPath);
        }

        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(imageFolderPath),
            RequestPath = $"/{imagePathOptions.PathImages}"
        });
    }
}
