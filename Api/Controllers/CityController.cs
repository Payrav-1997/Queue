using Api.ViewResponse;
using Domain.Requests.City;
using Microsoft.AspNetCore.Mvc;
using Service.City;

namespace Api.Controllers;

[Route("api/cities")]
public class CityController(ICityService cityService) : BaseController
{
    [HttpPost]
    public async Task<ApiResponse> Create(CreateCityRequest request)
    {
        await cityService.CreateAsync(request);

        return ApiResponse.Ok();
    }

    [HttpGet]
    public async Task<ApiResponse> GetAll([FromQuery] CityRequestParameter parameter)
    {
        var cities = await cityService.GetAllAsync(parameter);

        return ApiResponse.Success(cities);
    }

    [HttpGet("{cityId:guid}")]
    public async Task<ApiResponse> GetById(Guid cityId)
    {
        var city = await cityService.GetByIdAsync(cityId);

        return ApiResponse.Success(city);
    }

    [HttpPut("{cityId:guid}")]
    public async Task<ApiResponse> Update(Guid cityId, UpdateCityRequest request)
    {
        await cityService.UpdateAsync(cityId, request);

        return ApiResponse.Ok();
    }

    [HttpGet("list")]
    public async Task<ApiResponse> GetAll(Guid? regionId)
    {
        var cities = await cityService.GetAllAsync(null, regionId);

        return ApiResponse.Success(cities);
    }

    [HttpGet("list/{regionId::guid}")]
    public async Task<ApiResponse> GetByRegionId(Guid regionId)
    {
        var cities = await cityService.GetByRegionIdAsync(regionId);

        return ApiResponse.Success(cities);
    }

    [HttpDelete("{cityId:guid}")]
    public async Task<ApiResponse> DeleteAsync(Guid cityId)
    {
        await cityService.DeleteAsync(cityId);

        return ApiResponse.Ok();
    }
}