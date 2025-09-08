namespace Domain.Models.Entities;

public class Region : Entity
{
    public string Name { get; set; }

    public ICollection<City> Cities { get; set; }
}