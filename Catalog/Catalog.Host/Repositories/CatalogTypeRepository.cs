using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories
{
    public class CatalogTypeRepository : ICatalogTypeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<CatalogItemRepository> _logger;

        public CatalogTypeRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<CatalogItemRepository> logger)
        {
            _dbContext = dbContextWrapper.DbContext;
            _logger = logger;
        }

        public async Task<int?> Add(string type)
        {
            var result = await _dbContext.CatalogTypes.AddAsync(new CatalogType() { Type = type });
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<CatalogType?> GetByIdAsync(int id)
        {
            var result = await _dbContext.CatalogTypes.Where(i => i.Id == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<int?> Delete(int id)
        {
            var element = await GetByIdAsync(id);
            if (element != null)
            {
                _dbContext.CatalogTypes.Remove(element);
                await _dbContext.SaveChangesAsync();
                return id;
            }

            return null;
        }

        public async Task<CatalogType?> Update(int id, string property, string value)
        {
            var result = await GetByIdAsync(id);

            if (result != null)
            {
                var changingValue = result.GetType().GetProperty(property);
                if (changingValue != null)
                {
                    var propertyType = changingValue.PropertyType;
                    var res = Convert.ChangeType(value, propertyType);
                    changingValue.SetValue(result, res, null);
                    _dbContext.CatalogTypes.Update(result);
                    await _dbContext.SaveChangesAsync();
                    return result;
                }
            }

            return null;
        }
    }
}
