using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.GetSaleProduct;

/// <summary>
/// Command for retrieving a saleProduct by their ID
/// </summary>
public record GetSaleProductCommand : IRequest<IEnumerable<GetSaleProductResult>>
{
    /// <summary>
    /// The unique identifier of the saleProduct to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleProductCommand
    /// </summary>
    /// <param name="id">The ID of the saleProduct to retrieve</param>
    public GetSaleProductCommand(Guid id)
    {
        Id = id;
    }
}
