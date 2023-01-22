using Catalog.Host.Models.Dtos;

namespace Catalog.Host.Services.Interfaces
{
    public interface ICatalogBrandService
    {
        Task<int?> Add(string brand);
        Task<int?> Delete(int id);
        Task<CatalogBrandDto> Update(int id, string property, string value);
    }
}
