namespace Domain.Models.Entities;

public class OrganizationFeedback : Entity
{
    public Guid OrganizationId { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; }
    //оценка
    public int? Assessment { get; set; }
}