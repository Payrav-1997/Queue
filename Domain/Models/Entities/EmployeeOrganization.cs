namespace Domain.Models.Entities;

public class EmployeeOrganization
{
    public Guid EmployeeId { get; set; }
    public Guid OrganizationId { get; set; }
    
    public virtual Employee Employee { get; set; }
    public virtual Organization Organization { get; set; }
}