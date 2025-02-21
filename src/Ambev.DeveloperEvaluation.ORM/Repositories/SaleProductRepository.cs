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
    /// <param name="SaleProduct">The SaleProduct to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created SaleProduct</returns>
    public async Task<SaleProduct> CreateAsync(SaleProduct SaleProduct, CancellationToken cancellationToken = default)
    {
        await _context.SalesProducts.AddAsync(SaleProduct, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return SaleProduct;
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
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var SaleProduct = await GetByIdAsync(id, cancellationToken);
        if (SaleProduct == null)
            return false;

        _context.SalesProducts.Remove(SaleProduct);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
