namespace Domain.Models.Entities;

public class Position : Entity
{
    public ICollection<EmployeePosition>? Employees { get; set; }
}