using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.GetSaleProduct;

/// <summary>
/// Profile for mapping GetSaleProduct feature requests to commands
/// </summary>
public class GetSaleProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleProduct feature
    /// </summary>
    public GetSaleProductProfile()
    {
        CreateMap<Guid, Application.SaleProducts.GetSaleProduct.GetSaleProductCommand>()
            .ConstructUsing(id => new Application.SaleProducts.GetSaleProduct.GetSaleProductCommand(id));
    }
}
