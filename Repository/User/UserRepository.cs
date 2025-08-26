using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository.User;

public class UserRepository(DataContext context) : IUserRepository
{
    public async Task<Domain.Models.Entities.User?> GetByIdAsync(Guid userId)
    {
        return await context.Users.FindAsync(userId);
    }

    public Task<Domain.Models.Entities.User> FindByPhoneAsync(string requestPhone)
    {
        return context.Users.FirstOrDefaultAsync(x=>x.Phone == requestPhone);
    }
}