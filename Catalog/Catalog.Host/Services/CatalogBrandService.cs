using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;
        private readonly IMapper _mapper;

        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogBrandRepository = catalogBrandRepository;
            _mapper = mapper;
        }

        public async Task<int?> Add(string brand)
        {
            return await ExecuteSafeAsync(async () => await _catalogBrandRepository.Add(brand));
        }

        public async Task<int?> Delete(int id)
        {
            return await ExecuteSafeAsync(async () => await _catalogBrandRepository.Delete(id));
        }

        public Task<CatalogBrandDto> Update(int id, string property, string value)
        {
            return ExecuteSafeAsync(async () =>
            {
                var result = await _catalogBrandRepository.Update(id, property, value);
                return _mapper.Map<CatalogBrandDto>(result);
            });
        }
    }
}
