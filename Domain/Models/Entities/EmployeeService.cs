namespace Domain.Models.Entities;

public class EmployeeService
{
    public Guid ServiceId { get; set; }
    public Guid EmployeeId { get; set; }
    
    public virtual Employee Employee { get; set; }
    public virtual Service Service { get; set; }
}