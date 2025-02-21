using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.CreateSaleProduct;

/// <summary>
/// API response model for CreateSaleProduct operation
/// </summary>
public class CreateSaleProductResponse
{
    /// <summary>
    /// Gets or sets the Customer Name.
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Customer CPF/CNPJ.
    /// </summary>
    public string CpfCnpjCustomer { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Company Name.
    /// </summary>
    public string CompanyName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the User Name.
    /// </summary>
    public string UserName { get; set; } = string.Empty;
}
