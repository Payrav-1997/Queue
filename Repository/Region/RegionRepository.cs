using Domain.Common;
using Domain.Models;
using Domain.Requests.Region;
using Microsoft.EntityFrameworkCore;

namespace Repository.Region
{
    public class RegionRepository(DataContext context) : IRegionRepository
    {
        public async Task<Domain.Models.Entities.Region?> FindByNameAsync(string name)
        {
            return await context.Regions.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
        }

        public async Task CreateAsync(Domain.Models.Entities.Region region)
        {
            await context.Regions.AddAsync(region);
            await context.SaveChangesAsync();
        }

        public async Task<PagedResult<Domain.Models.Entities.Region>> GetAllAsync(RegionRequestParameter parameter)
        {
            var query = context.Regions.AsQueryable();

            var roles = new PaginationService<Domain.Models.Entities.Region>(query.Where(x =>
            parameter.Query == null || x!.Name.ToLower().Contains(parameter.Query.Trim().ToLower())));

            return await roles.GetPagedResultAsync(parameter.Page, parameter.PerPage);
        }

        public async Task<Domain.Models.Entities.Region?> GetByIdAsync(Guid regionId)
        {
            return await context.Regions.FindAsync(regionId);
        }

        public async Task UpdateAsync(Domain.Models.Entities.Region region)
        {
            context.Update(region);
            await context.SaveChangesAsync();
        }

        public async Task<List<Domain.Models.Entities.Region>> GetAllAsync()
        {
            var queryable = context.Regions.AsQueryable();

            return await queryable.ToListAsync();
        }

        public Task DeleteAsync(Domain.Models.Entities.Region region)
        {
            context.Regions.Remove(region);
            return context.SaveChangesAsync();
        }
    }
}
