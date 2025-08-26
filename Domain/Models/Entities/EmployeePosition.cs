namespace Domain.Models.Entities;

public class EmployeePosition
{
    public Guid EmployeeId { get; set; }
    public Guid PositionId { get; set; }
    public Position Position { get; set; }
    public Employee Employee { get; set; }
}