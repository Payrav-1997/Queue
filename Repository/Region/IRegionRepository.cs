using Domain.Common;
using Domain.Requests.Region;

namespace Repository.Region
{
    public interface IRegionRepository
    {
        Task<Domain.Models.Entities.Region?> FindByNameAsync(string name);

        Task CreateAsync(Domain.Models.Entities.Region region);

        Task<Domain.Models.Entities.Region?> GetByIdAsync(Guid regionId);

        Task UpdateAsync(Domain.Models.Entities.Region region);

        Task<PagedResult<Domain.Models.Entities.Region>> GetAllAsync(RegionRequestParameter parameter);

        Task<List<Domain.Models.Entities.Region>> GetAllAsync();
        Task DeleteAsync(Domain.Models.Entities.Region region);
    }
}