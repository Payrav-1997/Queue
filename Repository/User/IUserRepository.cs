using Domain.Models.ViewModels.User;

namespace Repository.User;

public interface IUserRepository
{
    Task<Domain.Models.Entities.User?> GetByIdAsync(Guid userId);
    Task<Domain.Models.Entities.User> FindByPhoneAsync(string requestPhone);
}