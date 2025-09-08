namespace Domain.ViewModels.City;

public class GetCityVm
{
    public Guid Id { get; set; }
    public string Name { get; set; }
   // public Guid RegionId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public static GetCityVm? FromEntity(Models.Entities.City? entity)
    {
        if (entity is null) return null;

        return new GetCityVm
        {
            Id = entity.Id,
            Name = entity.Name,
          //  RegionId = entity.RegionId,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
        };
    }
}