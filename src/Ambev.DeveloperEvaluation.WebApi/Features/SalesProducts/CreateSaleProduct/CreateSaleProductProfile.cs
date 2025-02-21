using AutoMapper;
using Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.CreateSaleProduct;

/// <summary>
/// Profile for mapping between Application and API CreateSaleProduct responses
/// </summary>
public class CreateSaleProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleProduct feature
    /// </summary>
    public CreateSaleProductProfile()
    {
        CreateMap<CreateSaleProductRequest, CreateSaleProductCommand>();
        CreateMap<CreateSaleProductResult, CreateSaleProductResponse>();
    }
}
