using Domain.Common;
using Domain.Requests;
using Domain.Requests.City;
using Domain.ViewModels;
using Domain.ViewModels.City;

namespace Service.City
{
    public interface ICityService
    {
        Task CreateAsync(CreateCityRequest request);

        Task<GetCityVm?> GetByIdAsync(Guid cityId);

        Task UpdateAsync(Guid cityId, UpdateCityRequest request);

        Task<PagedResult<GetCityVm?>> GetAllAsync(CityRequestParameter parameter);

        Task<List<BaseVm>> GetAllAsync(string? query, Guid? regionId);
        
        Task<List<BaseVm>> GetByRegionIdAsync(Guid regionId);

        Task DeleteAsync(Guid cityId);
    }
}