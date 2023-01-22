using System.Net;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBffController : ControllerBase
{
    private readonly ILogger<CatalogBffController> _logger;
    private readonly ICatalogService _catalogService;

    public CatalogBffController(
        ILogger<CatalogBffController> logger,
        ICatalogService catalogService)
    {
        _logger = logger;
        _catalogService = catalogService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Items(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetCatalogItemsAsync(request.PageSize, request.PageIndex);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(GetItemByIdResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(UniversalGetByIdRequest request)
    {
        var result = await _catalogService.GetByIdAsync(request.Id);
        if (result == null)
        {
            return BadRequest(new ErrorResponse() { ErrorMessage = "Undefined Id" });
        }
        else
        {
            return Ok(new GetItemByIdResponse()
            {
                Id = result.Id,
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                PictureUrl = result.PictureUrl,
                AvailableStock = result.AvailableStock,
                CatalogType = result.CatalogType,
                CatalogBrand = result.CatalogBrand
            });
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByBrand(PaginatedItemsByBrandRequest request)
    {
        var result = await _catalogService.GetByBrandAsync(request.Brand, request.PageIndex, request.PageSize);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogItemDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByType(PaginatedItemsByTypeRequest request)
    {
        var result = await _catalogService.GetByTypeAsync(request.Type, request.PageIndex, request.PageSize);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogBrandDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetBrands(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetBrandsAsync(request.PageIndex, request.PageSize);
        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(typeof(PaginatedItemsResponse<CatalogTypeDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetTypes(PaginatedItemsRequest request)
    {
        var result = await _catalogService.GetTypesAsync(request.PageIndex, request.PageSize);
        return Ok(result);
    }
}