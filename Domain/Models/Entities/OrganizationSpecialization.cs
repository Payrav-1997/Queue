namespace Domain.Models.Entities;

public class OrganizationSpecialization
{
    public Guid SpecializationId { get; set; }
    public Guid OrganizationId { get; set; }
    
    public Specialization Specialization { get; set; }
    public Organization Organization { get; set; }
}