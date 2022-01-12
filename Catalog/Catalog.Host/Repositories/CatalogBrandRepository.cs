using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogBrandRepository : ICatalogBrandRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogBrandRepository> _logger;

    public CatalogBrandRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogBrandRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int> Create(string title)
    {
        var item = _dbContext.CatalogBrands.Add(
            new CatalogBrand()
            {
                Brand = title
            });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<int> Update(int id, string title)
    {
        var itemToUpdate = _dbContext.CatalogBrands.First(ci => ci.Id == id);

        itemToUpdate.Brand = title;

        _dbContext.CatalogBrands.Update(itemToUpdate);
        await _dbContext.SaveChangesAsync();

        return itemToUpdate.Id;
    }

    public async Task<int> Delete(int id)
    {
        var itemToRemove = _dbContext.CatalogBrands.First(ci => ci.Id == id);

        _dbContext.CatalogBrands.Remove(itemToRemove);
        await _dbContext.SaveChangesAsync();

        return itemToRemove.Id;
    }
}