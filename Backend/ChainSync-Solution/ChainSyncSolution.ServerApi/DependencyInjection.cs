using Asp.Versioning;
using ChainSyncSolution.Application.Assets;
using ChainSyncSolution.ServerApi.Common.Settings;
using Microsoft.AspNetCore.ResponseCompression;

namespace ChainSyncSolution.ServerApi;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services, ConfigurationManager configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
            options.MimeTypes = ResponseCompressionDefaults
                   .MimeTypes.Concat(new[] { "image/svg+xml" });
        });

        services.Configure<BrotliCompressionProviderOptions>(options =>
        {
            options.Level = System.IO.Compression.CompressionLevel.Optimal;
        });

        services.Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = System.IO.Compression.CompressionLevel.SmallestSize;
        });

        services.Configure<AssetImageOptions>(configuration.GetSection(ImagePathSettings.PathSettings));

        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);

            options.ApiVersionReader = ApiVersionReader.Combine(
               new QueryStringApiVersionReader("api-version"),
               new HeaderApiVersionReader("X-Version"),
               new MediaTypeApiVersionReader("ver"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
}
