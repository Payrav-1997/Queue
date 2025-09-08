namespace Domain.Requests.City
{
    public class UpdateCityRequest
    {
        public string? Name { get; set; }
        public Guid? RegionId { get; set; }
    }
}
