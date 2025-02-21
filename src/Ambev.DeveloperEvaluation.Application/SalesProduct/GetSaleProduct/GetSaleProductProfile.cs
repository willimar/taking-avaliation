using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.GetSaleProduct;

/// <summary>
/// Profile for mapping between SaleProduct entity and GetSaleProductResponse
/// </summary>
public class GetSaleProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleProduct operation
    /// </summary>
    public GetSaleProductProfile()
    {
        CreateMap<SaleProduct, GetSaleProductResult>();
    }
}
