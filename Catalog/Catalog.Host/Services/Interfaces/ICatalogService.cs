using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    Task<CatalogItemDto> GetByIdAsync(int id);
    Task<PaginatedItemsResponse<CatalogItemDto>> GetByBrandAsync(string brand, int pageIndex, int pageSize);
    Task<PaginatedItemsResponse<CatalogItemDto>> GetByTypeAsync(string type, int pageIndex, int pageSize);
    Task<PaginatedItemsResponse<CatalogBrandDto>> GetBrandsAsync(int pageIndex, int pageSize);
    Task<PaginatedItemsResponse<CatalogTypeDto>> GetTypesAsync(int pageIndex, int pageSize);
}