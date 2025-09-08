namespace Domain.Requests.City;

public class CreateCityRequest
{
    public required string Name { get; set; }
    public required Guid RegionId { get; set; }
}