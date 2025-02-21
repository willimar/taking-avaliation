using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct;

/// <summary>
/// Profile for mapping between SaleProduct entity and CreateSaleProductResponse
/// </summary>
public class CreateSaleProductProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleProduct operation
    /// </summary>
    public CreateSaleProductProfile()
    {
        CreateMap<CreateSaleProductCommand, SaleProduct>();
        CreateMap<SaleProduct, CreateSaleProductResult>();
    }
}
