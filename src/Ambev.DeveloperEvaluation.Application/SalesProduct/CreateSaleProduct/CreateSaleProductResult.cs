namespace Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct;

/// <summary>
/// Represents the response returned after successfully creating a new SaleProduct.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created SaleProduct,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class CreateSaleProductResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created SaleProduct.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created SaleProduct in the system.</value>
    public Guid Id { get; set; }
}
