using Domain.Common;
using Domain.Exceptions;
using Domain.Requests;
using Domain.Requests.City;
using Domain.ViewModels;
using Domain.ViewModels.City;
using Repository.City;

namespace Service.City
{
    public class CityService(ICityRepository cityRepository) : ICityService
    {
        public async Task CreateAsync(CreateCityRequest request)
        {
            var city = await cityRepository.FindByNameAsync(request.Name);
            if (city is not null)
                throw new BadRequestException("Город уже существует!");

            var newCity = new Domain.Models.Entities.City()
            {
                Name = request.Name,
                RegionId = request.RegionId,
                CreatedAt = DateTime.Now,
            };

            await cityRepository.CreateAsync(newCity);
        }

        public async Task<PagedResult<GetCityVm?>> GetAllAsync(CityRequestParameter parameter)
        {
            var city = await cityRepository.GetAllAsync(parameter);

            return new PagedResult<GetCityVm?>()
            {
                Page = city.Page,
                Size = city.Size,
                TotalPages = city.TotalPages,
                TotalCount = city.TotalCount,
                Items = city.Items.Select(GetCityVm.FromEntity).ToList()
            };
        }

        public async Task<List<BaseVm>> GetAllAsync(string? query, Guid? regionId)
        {
            var cities = await cityRepository.GetAllAsync(query, regionId);
            return cities.Select(x => new BaseVm
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public async Task<List<BaseVm>> GetByRegionIdAsync(Guid regionId)
        {
            var cities = await cityRepository.GetByRegionIdAsync(regionId);
            return cities.Select(x => new BaseVm
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }

        public async Task<GetCityVm?> GetByIdAsync(Guid cityId)
        {
            var city = await cityRepository.GetByIdAsync(cityId);

            if (city is null)
                throw new BadRequestException("Город не найден!");

            return GetCityVm.FromEntity(city);
        }

        public async Task UpdateAsync(Guid cityId, UpdateCityRequest request)
        {
            var city = await cityRepository.GetByIdAsync(cityId);
            if (city is null)
                throw new BadRequestException("Город не найден!");

            city.Name = request.Name ?? city.Name;
            city.RegionId = request.RegionId ?? city.RegionId;
            city.UpdatedAt = DateTime.Now;

            await cityRepository.UpdateAsync(city);

        }
        
        public async Task DeleteAsync(Guid cityId)
        {
            var city = await cityRepository.GetByIdAsync(cityId);
            if (city is null)
                throw new BadRequestException("Город не найден!");

            await cityRepository.DeleteAsync(city);
        }
    }
}
