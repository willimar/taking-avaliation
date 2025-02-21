using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.DeleteSaleProduct;

/// <summary>
/// Profile for mapping DeleteSaleProduct feature requests to commands
/// </summary>
public class DeleteSaleProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteSaleProduct feature
    /// </summary>
    public DeleteSaleProductProfile()
    {
        CreateMap<Guid, Application.SaleProducts.DeleteSaleProduct.DeleteSaleProductCommand>()
            .ConstructUsing(id => new Application.SaleProducts.DeleteSaleProduct.DeleteSaleProductCommand(id));
    }
}
