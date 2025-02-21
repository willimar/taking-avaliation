namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.GetSaleProduct;

/// <summary>
/// Request model for getting a user by ID
/// </summary>
public class GetSaleProductRequest
{
    /// <summary>
    /// The unique identifier of the user to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
