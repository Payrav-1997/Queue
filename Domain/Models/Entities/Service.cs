namespace Domain.Models.Entities;

public class Service : Entity
{
    public string Name { get; set; }
    public double? Amount { get; set; }
    public ICollection<EmployeeService> Employees { get; set; }
}