namespace Domain.Models.Entities;

public class EmployeeFeedback : Entity
{
    public Guid EmployeeId { get; set; }
    public Guid UserId { get; set; }
    public string Text { get; set; }
    //оценка
    public int? Assessment { get; set; }
}