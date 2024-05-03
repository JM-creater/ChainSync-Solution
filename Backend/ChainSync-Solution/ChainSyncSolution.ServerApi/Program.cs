using ChainSyncSolution.Application;
using ChainSyncSolution.Application.Assets;
using ChainSyncSolution.Infrastructure;
using ChainSyncSolution.ServerApi;
using ChainSyncSolution.ServerApi.Common.Errors;
using ChainSyncSolution.ServerApi.Common.Settings;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation()
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration);

    builder.Services.AddResponseCompression(options =>
    {
        options.EnableForHttps = true;
        options.Providers.Add<BrotliCompressionProvider>();
        options.Providers.Add<GzipCompressionProvider>();
        options.MimeTypes = ResponseCompressionDefaults
               .MimeTypes.Concat(new[] { "image/svg+xml" });
    });

    builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
    {
        options.Level = System.IO.Compression.CompressionLevel.Optimal;
    });

    builder.Services.Configure<GzipCompressionProviderOptions>(options =>
    {
        options.Level = System.IO.Compression.CompressionLevel.SmallestSize;
    });

    builder.Services.Configure<AssetImageOptions>(builder.Configuration.GetSection(ImagePathSettings.PathSettings));
}

var app = builder.Build();
{
    app.ConfigureFigures(builder.Configuration);

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionHandlingMiddleware>();

    app.MapHealthChecks("/health");

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

