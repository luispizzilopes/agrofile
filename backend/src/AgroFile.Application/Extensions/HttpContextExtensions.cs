using Microsoft.AspNetCore.Http;

namespace AgroFile.Application.Extensions; 

public static class HttpContextExtensions
{
    public static string GetBaseUrl(this HttpContext httpContext)
    {
        if (httpContext?.Request == null) return string.Empty;
        return $"{httpContext.Request.Scheme}://{httpContext.Request.Host.Value}";
    }
}
