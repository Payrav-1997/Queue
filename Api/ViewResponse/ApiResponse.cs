using System.Net;

namespace Api.ViewResponse;

public class ApiResponse
{

    private ApiResponse(bool isSuccess, object? data, string? message = null)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }

    public bool IsSuccess { get; set; }
    public object? Data { get; set; }
    public string? Message { get; set; }

    public static ApiResponse Success(object? data, string? message = "Success")
    {
        return new ApiResponse(true, data, message);
    }

    public static ApiResponse Error(HttpContext httpContext, string? message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        httpContext.Response.StatusCode = (int)statusCode;
        return new ApiResponse(false, null, message);
    }

    public static ApiResponse Ok(string? message = "Success") 
    {
        return new ApiResponse(true, null, message);
    }

    public static ApiResponse BadRequest(string message, HttpStatusCode statusCode)
    {

        return new ApiResponse(false, null, message);
    }

    public static ApiResponse NotFound(HttpContext httpContext, string? message = "Not found", HttpStatusCode statusCode = HttpStatusCode.NotFound)
    {
        return Error(httpContext, message, statusCode);
    }

    private void SetStatusCode(HttpContext context, int statusCode)
    {
        context.Response.StatusCode = statusCode;
    }
}