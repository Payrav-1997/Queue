using Domain.Models.Enums;

namespace Domain.Models.Entities;

public class Employee : Entity
{
    public string FullName { get; set; }
    public string? Phone { get; set; }
    public string? ImageUrl { get; set; }
    public string WorkExperience { get; set; }
    public string? Descriotion { get; set; }
    public Gander GanderId { get; set; }

    public virtual ICollection<EmployeePosition>? Positions { get; set; }
    public virtual ICollection<EmployeeFeedback>? Feedbacks { get; set; }
    public virtual ICollection<EmployeeService>? Services { get; set; }
    public virtual ICollection<EmployeeOrganization> Organizations { get; set; }
}