using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.GetSaleProduct;

/// <summary>
/// Response model for GetSaleProduct operation
/// </summary>
public class GetSaleProductResult
{
    public Guid ProductId { get; set; }

    /// <summary>
    /// The Name of the Product
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// The Value of the Product in the sale day
    /// </summary>
    public decimal UnitValue { get; set; }

    /// <summary>
    /// The discount of the product in the sale day
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// The total value of the product in the sale day
    /// </summary>
    public decimal TotalUnityValue { get; set; }

    /// <summary>
    /// If the product was canceled in the sale
    /// </summary>
    public bool Canceled { get; set; }

    /// <summary>
    /// The quantity of the product in the sale
    /// </summary>
    public int Count { get; set; }
}
