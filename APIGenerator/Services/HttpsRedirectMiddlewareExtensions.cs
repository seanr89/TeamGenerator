
using Microsoft.AspNetCore.Builder;

namespace APIGenerator.Services
{
        public static class HttpsRedirectMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpsRedirect(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HttpsRedirectMiddleware>();
        }
    }
}