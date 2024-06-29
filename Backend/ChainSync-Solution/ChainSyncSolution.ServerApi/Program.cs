using ChainSyncSolution.Application;
using ChainSyncSolution.Infrastructure;
using ChainSyncSolution.ServerApi;
using ChainSyncSolution.ServerApi.Common.Errors;
using ChainSyncSolution.ServerApi.Common.Policy;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation(builder.Configuration)
                    .AddApplication()
                    .AddInfrastructure(builder.Configuration)
                    .AddCorsPolicy();
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

    app.UseCors();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

