using Domain.Common;
using Domain.Requests.Region;
using Domain.ViewModels;
using Domain.ViewModels.Region;

namespace Service.Region
{
    public interface IRegionService
    {
        Task CreateAsync(CreateRegionRequest request);

        Task<GetRegionVm> GetByIdAsync(Guid regionId);

        Task UpdateAsync(Guid regionId, UpdateRegionRequest request);

        Task<PagedResult<GetRegionVm>> GetAllAsync(RegionRequestParameter parameter);

        Task<List<BaseVm>> GetAllAsync();
        Task DeleteAsync(Guid regionId);
    }
}
