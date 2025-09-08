using Api.ViewResponse;
using Domain.Requests.Region;
using Microsoft.AspNetCore.Mvc;
using Service.Region;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/regions")]
    public class RegionController(IRegionService regionService) : BaseController
    {
        [HttpPost]
        public async Task<ApiResponse> Create(CreateRegionRequest request)
        {
            await regionService.CreateAsync(request);

            return ApiResponse.Ok();
        }

        [HttpGet]
        public async Task<ApiResponse> GetAll([FromQuery] RegionRequestParameter parameter)
        {
            var regions = await regionService.GetAllAsync(parameter);

            return ApiResponse.Success(regions);
        }

        [HttpGet("{regionId:guid}")]
        public async Task<ApiResponse> GetById(Guid regionId)
        {
            var region = await regionService.GetByIdAsync(regionId);

            return ApiResponse.Success(region);
        }

        [HttpPut("{regionId:guid}")]
        public async Task<ApiResponse> Update(Guid regionId, UpdateRegionRequest request)
        {
            await regionService.UpdateAsync(regionId, request);

            return ApiResponse.Ok();
        }

        [HttpGet("list")]
        public async Task<ApiResponse> GetAll()
        {
            var regions = await regionService.GetAllAsync();

            return ApiResponse.Success(regions);
        }

        [HttpDelete("{regionId:guid}")]
        public async Task<ApiResponse> DeleteAsync(Guid regionId)
        {
            await regionService.DeleteAsync(regionId);

            return ApiResponse.Ok();
        }
    }
}