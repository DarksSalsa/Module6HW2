using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<CatalogBrand?> GetByIdAsync(int id);
        Task<int?> Add(string brand);
        Task<int?> Delete(int id);
        Task<CatalogBrand?> Update(int id, string property, string value);
    }
}
