namespace Domain.Models.Entities;

public class Organization : Entity
{
    public string Name { get; set; }
    public string? LogoUrl { get; set; }
    public string? Description { get; set; }
    public string Address { get; set; }
    public Guid CityId { get; set; }
    public string? TelegramId { get; set; }
    public string? TelegramUserName { get; set; }
    public City City { get; set; }
    
    public ICollection<OrganizationSpecialization> Specializations { get; set; }
    public ICollection<OrganizationFeedback> Feedbacks { get; set; }
}