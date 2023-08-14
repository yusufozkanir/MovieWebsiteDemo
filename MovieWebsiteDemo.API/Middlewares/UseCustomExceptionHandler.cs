using Microsoft.AspNetCore.Diagnostics;
using MovieWebsiteDemo.Core.DTOs;
using MovieWebsiteDemo.Service.Business.Exceptions;
using System.Text.Json;

namespace MovieWebsiteDemo.API.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFuture = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFuture.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDto<NoContentDto>.Fail(statusCode, exceptionFuture.Error.Message, false);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });
            });
        }
    }
}
