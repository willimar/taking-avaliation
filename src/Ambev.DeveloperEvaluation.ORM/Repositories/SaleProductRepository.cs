using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Ambev.DeveloperEvaluation.ORM.Repositories;

/// <summary>
/// Implementation of ISaleProductRepository using Entity Framework Core
/// </summary>
public class SaleProductRepository : ISaleProductRepository
{
    private readonly DefaultContext _context;

    /// <summary>
    /// Initializes a new instance of SaleProductRepository
    /// </summary>
    /// <param name="context">The database context</param>
    public SaleProductRepository(DefaultContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Creates a new SaleProduct in the database
    /// </summary>
    /// <param name="saleProduct">The SaleProduct to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created SaleProduct</returns>
    public async Task<SaleProduct> CreateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default)
    {
        await _context.SalesProducts.AddAsync(saleProduct, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return saleProduct;
    }

    /// <summary>
    /// Retrieves a SaleProduct by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the SaleProduct</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The SaleProduct if found, null otherwise</returns>
    public async Task<SaleProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.SalesProducts.FirstOrDefaultAsync(o => o.Id == id, cancellationToken);
    }

    /// <summary>
    /// Deletes a SaleProduct from the database
    /// </summary>
    /// <param name="id">The unique identifier of the SaleProduct to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the SaleProduct was deleted, false if not found</returns>
    public async Task<SaleProduct?> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var saleProduct = await GetByIdAsync(id, cancellationToken);
        if (saleProduct == null)
            return null;

        saleProduct.Canceled = true;

        return await UpdateAsync(saleProduct, cancellationToken);
    }

    public async Task<decimal> GetTotalBySaleIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _context.SalesProducts.Where(x => x.SaleId == id && !x.Canceled).SumAsync(x => x.TotalUnityValue * x.Count);

        return result;
    }

    public async Task<SaleProduct> UpdateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default)
    {
        _context.SalesProducts.Update(saleProduct);
        await _context.SaveChangesAsync(cancellationToken);
        return saleProduct;
    }

    public async Task<SaleProduct?> GetByIdAsync(Guid productId, Guid saleId, CancellationToken cancellationToken = default)
    {
        return await _context.SalesProducts.FirstOrDefaultAsync(o => o.SaleId == saleId && o.ProductId == productId, cancellationToken);
    }
}
