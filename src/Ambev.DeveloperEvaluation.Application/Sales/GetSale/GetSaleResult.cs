using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The sale's Title
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The sale's Image address
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// The sale's Category
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// The sale's Price
    /// </summary>
    public double Price { get; set; }
}
