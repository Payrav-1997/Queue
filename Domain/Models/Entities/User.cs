using Domain.Models.ViewModels.User;

namespace Domain.Models.Entities;

public class User : Entity
{
    public string FullName { get; set; }
    public string Phone { get; set; }
    public DateTime? BirthDate { get; set; }

    public static UserVm Entity(User user)
    {
        return new UserVm()
        {
            Id = user.Id,
            FullName = user.FullName,
            Phone = user.Phone,
            BirthDate = user.BirthDate,
            CreatedAt = user.CreatedAt,
            UpdatedAt = user.UpdatedAt
        };
    }
}