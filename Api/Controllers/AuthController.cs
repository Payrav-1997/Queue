using Api.ViewResponse;
using Domain.Models.Requests.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Auth;

namespace Api.Controllers;

[ApiController]
[Route("api/auth/")]
public class AuthController(IAuthService authService) : BaseController
{
    [HttpPost("login")]
    public async Task<ApiResponse> Login(LoginRequest request)
    {
        var response = await authService.LoginAccount(request);
        return ApiResponse.Success(response);
    }
    
    [HttpGet("me")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<ApiResponse> Me()
    {
        var userId = GetCurrentUserId();
        var response = await authService.Me(userId);
        return ApiResponse.Success(response);
    }

    [HttpPost("change-password")]
    public async Task<ApiResponse> ChangePassword([FromBody] ChangePasswordRequest request)
    {
        var userId = GetCurrentUserId();
        await authService.ChangePasswordAsync(userId, request);

        return ApiResponse.Ok();
    }
}