using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// Gets or sets the Sale Number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Sale Date.
    /// </summary>
    public DateTime Date { get; set; }

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

    /// <summary>
    /// Gets or sets the Total Value of the Sale.
    /// </summary>
    public decimal TotalValue { get; set; }

    /// <summary>
    /// Gets or sets the Sale Status.
    /// </summary>
    public SaleStatus Status { get; set; }
}
