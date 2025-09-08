using Domain.Common;
using Domain.Models;
using Domain.Requests;
using Domain.Requests.City;
using Microsoft.EntityFrameworkCore;

namespace Repository.City
{
    public class CityRepository(DataContext context) : ICityRepository
    {
        public async Task CreateAsync(Domain.Models.Entities.City city)
        {
            await context.Cities.AddAsync(city);
            await context.SaveChangesAsync();
        }

        public async Task<Domain.Models.Entities.City?> FindByNameAsync(string name)
        {
            return await context.Cities.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
        }

        public async Task<PagedResult<Domain.Models.Entities.City>> GetAllAsync(CityRequestParameter parameter)
        {
            var queryable = context.Cities
                .Where(x => parameter.Query == null || x.Name.ToLower().Contains(parameter.Query.Trim().ToLower()));

            if (parameter.RegionId is not null)
                queryable = queryable.Where(city => city.RegionId.Equals(parameter.RegionId));

            var cities = new PaginationService<Domain.Models.Entities.City>(queryable);

            return await cities.GetPagedResultAsync(parameter.Page, parameter.PerPage);
        }

        public async Task<List<Domain.Models.Entities.City>> GetAllAsync(string? query, Guid? regionId)
        {
            var queryable = context.Cities.AsQueryable();

            if (query is not null)
                queryable = queryable.Where(city => city.Name.Trim().ToLower().Contains(query.Trim().ToLower()));

            if (regionId is not null)
                queryable = queryable.Where(city => city.RegionId.Equals(regionId));
            
            return await queryable.ToListAsync();
        }

        public async Task<List<Domain.Models.Entities.City>> GetByRegionIdAsync(Guid regionId)
        {
            return await context.Cities.Where(city => city.RegionId.Equals(regionId)).ToListAsync();
        }

        public Task DeleteAsync(Domain.Models.Entities.City city)
        {
            context.Cities.Remove(city);
            return context.SaveChangesAsync();
        }

        public async Task<Domain.Models.Entities.City?> GetByIdAsync(Guid cityId)
        {
            return await context.Cities.FirstOrDefaultAsync(city => city.Id.Equals(cityId));
        }

        public async Task UpdateAsync(Domain.Models.Entities.City city)
        {
            context.Update(city);
            await context.SaveChangesAsync();
        }
    }
}
