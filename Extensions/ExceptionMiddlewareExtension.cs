using Microsoft.AspNetCore.Diagnostics;
using backend.Entities.ResponseObjects;
using System.Net;

namespace backend.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature is not null)
                    {
                        await context.Response.WriteAsync(new ErrorResponse(context.Response.StatusCode, contextFeature.Error.Message).ToString());
                    }
                });
            });
        }
    }
}
