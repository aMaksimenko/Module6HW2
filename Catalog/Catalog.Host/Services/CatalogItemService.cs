using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogItemService : BaseDataService<ApplicationDbContext>, ICatalogItemService
{
    private readonly ICatalogItemRepository _catalogItemRepository;

    public CatalogItemService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
    }

    public Task<int> Create(
        string name,
        string description,
        decimal price,
        int availableStock,
        int catalogBrandId,
        int catalogTypeId,
        string pictureFileName)
    {
        return ExecuteSafe(
            () => _catalogItemRepository.Create(
                name,
                description,
                price,
                availableStock,
                catalogBrandId,
                catalogTypeId,
                pictureFileName));
    }

    public Task<int> Update(
        int id,
        string name,
        string description,
        decimal price,
        int availableStock,
        int catalogBrandId,
        int catalogTypeId,
        string pictureFileName)
    {
        return ExecuteSafe(
            () => _catalogItemRepository.Update(
                id,
                name,
                description,
                price,
                availableStock,
                catalogBrandId,
                catalogTypeId,
                pictureFileName));
    }

    public Task<int> Delete(int id)
    {
        return ExecuteSafe(() => _catalogItemRepository.Delete(id));
    }
}