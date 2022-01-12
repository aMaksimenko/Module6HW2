using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
{
    private readonly ICatalogTypeRepository _catalogTypeRepository;

    public CatalogTypeService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogTypeRepository catalogTypeRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogTypeRepository = catalogTypeRepository;
    }

    public Task<int> Create(string title)
    {
        return ExecuteSafe(() => _catalogTypeRepository.Create(title));
    }

    public Task<int> Update(int id, string title)
    {
        return ExecuteSafe(() => _catalogTypeRepository.Update(id, title));
    }

    public Task<int> Delete(int id)
    {
        return ExecuteSafe(() => _catalogTypeRepository.Delete(id));
    }
}