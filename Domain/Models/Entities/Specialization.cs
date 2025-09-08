namespace Domain.Models.Entities;

public class Specialization : Entity
{
    public string Name { get; set; }

    public ICollection<OrganizationSpecialization> Organizations { get; set; }
}