using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly IMapper _mapper;

        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogTypeRepository catalogTypeRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _catalogTypeRepository = catalogTypeRepository;
            _mapper = mapper;
        }

        public async Task<int?> Add(string brand)
        {
            return await ExecuteSafeAsync(async () => await _catalogTypeRepository.Add(brand));
        }

        public async Task<int?> Delete(int id)
        {
            return await ExecuteSafeAsync(async () => await _catalogTypeRepository.Delete(id));
        }

        public Task<CatalogTypeDto> Update(int id, string property, string value)
        {
            return ExecuteSafeAsync(async () =>
            {
                var result = await _catalogTypeRepository.Update(id, property, value);
                return _mapper.Map<CatalogTypeDto>(result);
            });
        }
    }
}
