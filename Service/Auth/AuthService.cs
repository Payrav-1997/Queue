using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Exceptions;
using Domain.Models.Entities;
using Domain.Models.Requests.Auth;
using Domain.Models.ViewModels.Auth;
using Domain.Models.ViewModels.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Repository.User;

namespace Service.Auth;

public class AuthService(IUserRepository userRepository, IConfiguration config) : IAuthService
{
    public async Task<LoginVm> LoginAccount(LoginRequest request)
    {
        var user = await userRepository.FindByPhoneAsync(request.Phone);
        if (user is null)
            throw new BadRequestException("Пользователь не найден!");
        

        var token = GenerateToken(user);
        return new LoginVm()
        {
            UserId = user.Id,
            Token = token
        };
    }

    public async Task<UserVm> Me(Guid userId)
    {
        var user = await userRepository.GetByIdAsync(userId);
        if (user is null)
            throw new EntityNotFoundException("Пользователь не найден!");

        var newUser = User.Entity(user);
        
        return newUser;
    }

    public async Task ChangePasswordAsync(Guid userId, ChangePasswordRequest request)
    {
        var user = await userRepository.GetByIdAsync(userId);
        if (user == null)
            throw new EntityNotFoundException("Пользователь не найден!");
        
        // var checkUserPasswords = await userRepository.CheckPasswordAsync(user, request.OldPassword);
        // if (!checkUserPasswords)
        //     throw new BadRequestException("Вы не верно ввели старый пароль");
        
    }

    private string GenerateToken(User user)
    {
        var securityKey = Encoding.UTF8.GetBytes(config["Jwt:Key"]!);
        var credentials = new SigningCredentials(
            new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);
        var userClaims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
           new Claim("Phone", user!.Phone)
        };
        var token = new JwtSecurityToken(
            issuer: "test",
            audience: "test",
            claims: userClaims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}