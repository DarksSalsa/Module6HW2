using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogTypeService
    {
        Task<int?> Add(string brand);
        Task<int?> Delete(int id);
        Task<CatalogTypeDto> Update(int id, string property, string value);
    }
}
