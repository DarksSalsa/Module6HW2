using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogTypeRepository
    {
        Task<CatalogType?> GetByIdAsync(int id);
        Task<int?> Add(string type);
        Task<int?> Delete(int id);
        Task<CatalogType?> Update(int id, string property, string value);
    }
}
