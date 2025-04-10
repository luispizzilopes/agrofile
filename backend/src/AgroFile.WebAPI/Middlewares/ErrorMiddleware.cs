using AgroFile.Domain.Common;
using AgroFile.Shared.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace AgroFile.WebAPI.Middlewares;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        Result errorResult;

        errorResult = Result.Failure(ex.InnerException?.Message ?? ex.Message);

        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

        var settings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        var result = JsonConvert.SerializeObject(errorResult, settings);
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(result);
    }
}

