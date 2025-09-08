namespace Domain.Models.Entities;

public class City : Entity
{
    public string Name { get; set; }
    
    public Guid RegionId { get; set; }
    public Region Region { get; set; }
}