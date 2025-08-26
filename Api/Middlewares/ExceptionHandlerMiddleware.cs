using System.Text.Json;
using Api.ViewResponse;
using Domain.Exceptions;

namespace Api.Middlewares;

public class ExceptionHandlerMiddleware(RequestDelegate requestDelegate)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await requestDelegate.Invoke(context);
        }
        catch (Exception e)
        {
            await HandleExceptionMessageAsync(context, e);
        }
    }

    private static Task HandleExceptionMessageAsync(HttpContext context, Exception exception)
    {
        var serializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        context.Response.ContentType = "application/json";
        switch (exception)
        {
            case EntityNotFoundException e:
                return context.Response.WriteAsync(JsonSerializer.Serialize(ApiResponse.Error(context, e.Message), serializeOptions));
            case BadRequestException e:
                return context.Response.WriteAsync(JsonSerializer.Serialize(ApiResponse.Error(context, e.Message), serializeOptions));
            default:
                context.Response.StatusCode = 500;
                return context.Response.WriteAsync(JsonSerializer.Serialize(ApiResponse.Error(context, exception.Message), serializeOptions));
        }
    }
}

