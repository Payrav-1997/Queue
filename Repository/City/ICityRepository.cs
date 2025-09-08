using Domain.Common;
using Domain.Requests;
using Domain.Requests.City;

namespace Repository.City
{
    public interface ICityRepository
    {
        Task<Domain.Models.Entities.City?> FindByNameAsync(string name);

        Task CreateAsync(Domain.Models.Entities.City city);

        Task<Domain.Models.Entities.City?> GetByIdAsync(Guid cityId);

        Task UpdateAsync(Domain.Models.Entities.City city);

        Task<PagedResult<Domain.Models.Entities.City>> GetAllAsync(CityRequestParameter parameter);

        Task<List<Domain.Models.Entities.City>> GetAllAsync(string? query, Guid? regionId);
        
        Task<List<Domain.Models.Entities.City>> GetByRegionIdAsync(Guid regionId);
        Task DeleteAsync(Domain.Models.Entities.City city);
    }
}