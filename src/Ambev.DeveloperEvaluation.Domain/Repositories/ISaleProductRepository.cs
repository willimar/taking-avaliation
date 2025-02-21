using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories;

/// <summary>
/// Repository interface for sale entity operations
/// </summary>
public interface ISaleProductRepository
{
    /// <summary>
    /// Creates a new sale in the repository
    /// </summary>
    /// <param name="sale">The sale to create</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created sale</returns>
    Task<SaleProduct> CreateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates a sale in the repository
    /// </summary>
    /// <param name="sale"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaleProduct> UpdateAsync(SaleProduct saleProduct, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by their unique identifier
    /// </summary>
    /// <param name="id">The unique identifier of the sale</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The sale if found, null otherwise</returns>
    Task<SaleProduct?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a sale by their sale and product identifier
    /// </summary>
    /// <param name="productId"></param>
    /// <param name="saleId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<SaleProduct?> GetByIdAsync(Guid productId, Guid saleId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a sale from the repository
    /// </summary>
    /// <param name="id">The unique identifier of the sale to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>True if the sale was deleted, false if not found</returns>
    Task<SaleProduct?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the total value of a sale by their sale identifier
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<decimal> GetTotalBySaleIdAsync(Guid id, CancellationToken cancellationToken = default);
}