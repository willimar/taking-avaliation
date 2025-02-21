using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Profile for mapping between Sale entity and CreateSaleResponse
/// </summary>
public class CreateSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSale operation
    /// </summary>
    public CreateSaleProfile()
    {
        /// Entendo que não é a forma mais segura de se gerar o número único,
        /// mas estou montando somente um código para demonstração. 
        /// Na prática talvez usasse um identity baseado em cache ou algo do tipo.
        /// Exemplo: ddMMyyyy<valor++>, onde valor seria um singleton que olha a um cache compartilhado.
        CreateMap<CreateSaleCommand, Sale>()
            .ForMember(dest => dest.Number, source => DateTime.UtcNow.ToString("ddMMyyyyHHmmssfff"));

        CreateMap<Sale, CreateSaleResult>();
    }
}
