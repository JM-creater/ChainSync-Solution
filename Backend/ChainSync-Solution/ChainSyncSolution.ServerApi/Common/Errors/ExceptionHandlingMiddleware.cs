﻿using ChainSyncSolution.Application.Common.Exceptions.Base;
using ChainSyncSolution.ServerApi.Common.Settings;

namespace ChainSyncSolution.ServerApi.Common.Errors;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BaseException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new { error = ex.Message });
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsJsonAsync(new { error = ErrorSettings.ErrorSetting, details = ex.Message });
        }
    }
}
