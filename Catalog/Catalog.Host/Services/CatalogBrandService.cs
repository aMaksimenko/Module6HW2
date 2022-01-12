using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
{
    private readonly ICatalogBrandRepository _catalogBrandRepository;

    public CatalogBrandService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogBrandRepository catalogBrandRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogBrandRepository = catalogBrandRepository;
    }

    public Task<int> Create(string title)
    {
        return ExecuteSafe(() => _catalogBrandRepository.Create(title));
    }

    public Task<int> Update(int id, string title)
    {
        return ExecuteSafe(() => _catalogBrandRepository.Update(id, title));
    }

    public Task<int> Delete(int id)
    {
        return ExecuteSafe(() => _catalogBrandRepository.Delete(id));
    }
}