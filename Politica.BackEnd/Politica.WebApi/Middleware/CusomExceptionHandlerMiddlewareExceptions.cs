using Microsoft.AspNetCore.Builder;

namespace Politica.WebApi.Middleware
{
    public static class CusomExceptionHandlerMiddlewareExceptions
    {
        public static IApplicationBuilder UseCusomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CusomExceptionHandlerMiddleware>();
        }
    }
}
