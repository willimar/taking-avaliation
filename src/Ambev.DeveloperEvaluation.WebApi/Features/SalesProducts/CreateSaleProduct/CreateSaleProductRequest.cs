using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.CreateSaleProduct;

/// <summary>
/// Represents a request to create a new saleProduct in the system.
/// </summary>
public class CreateSaleProductRequest
{
    /// <summary>
    /// The Id of the Sale
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// The Id of the Product
    /// </summary>
    public Guid ProductId { get; set; }

    /// <summary>
    /// The quantity of the product in the sale
    /// </summary>
    public int Count { get; set; }
}