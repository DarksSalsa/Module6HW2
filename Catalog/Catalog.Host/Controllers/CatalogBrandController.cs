using System.Net;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogBrandController : ControllerBase
{
    private readonly ILogger<CatalogBrandController> _logger;
    private readonly ICatalogBrandService _catalogBrandService;

    public CatalogBrandController(ILogger<CatalogBrandController> logger, ICatalogBrandService catalogBrandService)
    {
        _logger = logger;
        _catalogBrandService = catalogBrandService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(UniversalAddResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateBrandRequest request)
    {
        var result = await _catalogBrandService.Add(request.Brand);
        return Ok(new UniversalAddResponse<int?>() { Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UniversalDeleteResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(UniversalDeleteRequest request)
    {
        var result = await _catalogBrandService.Delete(request.Id);
        if (result == null)
        {
            return BadRequest(new ErrorResponse() { ErrorMessage = "Undefined Id" });
        }

        return Ok(new UniversalDeleteResponse() { Message = "Success", Id = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(BrandUpdateResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UniversalUpdateRequest request)
    {
        var result = await _catalogBrandService.Update(request.Id, request.Property, request.Value);
        if (result == null)
        {
            return BadRequest(new ErrorResponse() { ErrorMessage = "Undefined Id or Property" });
        }

        return Ok(new BrandUpdateResponse()
        {
            Id = result.Id,
            Brand = result.Brand
        });
    }
}