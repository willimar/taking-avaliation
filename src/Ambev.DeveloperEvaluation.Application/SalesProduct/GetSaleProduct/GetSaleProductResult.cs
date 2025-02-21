using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.GetSaleProduct;

/// <summary>
/// Response model for GetSaleProduct operation
/// </summary>
public class GetSaleProductResult
{
    /// <summary>
    /// The unique identifier of the saleProduct
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The saleProduct's Title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The saleProduct's Image address
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// The saleProduct's Category
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// The saleProduct's Price
    /// </summary>
    public double Price { get; set; }
}
