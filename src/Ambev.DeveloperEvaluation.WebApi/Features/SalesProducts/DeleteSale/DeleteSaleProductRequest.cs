namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.DeleteSaleProduct;

/// <summary>
/// Request model for deleting a user
/// </summary>
public class DeleteSaleProductRequest
{
    /// <summary>
    /// The unique identifier of the user to delete
    /// </summary>
    public Guid Id { get; set; }
}
