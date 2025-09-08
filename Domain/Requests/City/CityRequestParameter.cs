using Domain.Common;

namespace Domain.Requests.City;

public class CityRequestParameter : RequestParameters
{
    public Guid? RegionId { get; set; }
}