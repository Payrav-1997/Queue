using Domain.Common;
using Domain.Exceptions;
using Domain.Requests.Region;
using Domain.ViewModels;
using Domain.ViewModels.Region;
using Repository.Region;

namespace Service.Region
{
    public class RegionService(IRegionRepository regionRepository) : IRegionService
    {
        public async Task CreateAsync(CreateRegionRequest request)
        {
            var region = await regionRepository.FindByNameAsync(request.Name);
            if (region is not null)
                throw new BadRequestException("Регион уже существует!");

            var newRegion = new Domain.Models.Entities.Region()
            {
                Name = request.Name,
                CreatedAt = DateTime.Now,
            };
            await regionRepository.CreateAsync(newRegion);
        }

        public async Task<PagedResult<GetRegionVm>> GetAllAsync(RegionRequestParameter parameter)
        {
            var region = await regionRepository.GetAllAsync(parameter);

            return new PagedResult<GetRegionVm>()
            {
                Page = region.Page,
                Size = region.Size,
                TotalPages = region.TotalPages,
                TotalCount = region.TotalCount,
                Items = region.Items.Select(x => new GetRegionVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedAt = x.CreatedAt,
                    UpdatedAt = x.UpdatedAt
                }).ToList()
            };
        }

        public async Task<List<BaseVm>> GetAllAsync()
        {
            var cities = await regionRepository.GetAllAsync();
            return cities.Select(x => new BaseVm
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public async Task DeleteAsync(Guid regionId)
        {
            var region = await regionRepository.GetByIdAsync(regionId);
            if (region is null)
                throw new BadRequestException("Регион не найден!");
            
            await regionRepository.DeleteAsync(region);
        }

        public async Task<GetRegionVm> GetByIdAsync(Guid regionId)
        {
            var region = await regionRepository.GetByIdAsync(regionId);
            if (region is null)
                throw new BadRequestException("Регион не найден!");

            return new GetRegionVm()
            {
                Id = region.Id,
                Name = region.Name,
                CreatedAt = region.CreatedAt,
                UpdatedAt = region.UpdatedAt
            };
        }

        public async Task UpdateAsync(Guid regionId, UpdateRegionRequest request)
        {
            var region = await regionRepository.GetByIdAsync(regionId);
            if (region is null)
                throw new BadRequestException("Регион не найден!");

            region.Name = request.Name ?? region.Name;
            region.UpdatedAt = DateTime.Now;

            await regionRepository.UpdateAsync(region);
        }
    }
}
