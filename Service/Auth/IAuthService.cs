using Domain.Models.Requests.Auth;
using Domain.Models.ViewModels.Auth;
using Domain.Models.ViewModels.User;

namespace Service.Auth;

public interface IAuthService
{
    Task<LoginVm> LoginAccount(LoginRequest request);
    Task<UserVm> Me(Guid userId);
    Task ChangePasswordAsync(Guid userId, ChangePasswordRequest request);
}