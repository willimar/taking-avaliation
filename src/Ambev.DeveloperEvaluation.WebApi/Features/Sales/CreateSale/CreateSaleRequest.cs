using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Represents a request to create a new sale in the system.
/// </summary>
public class CreateSaleRequest
{
    /// <summary>
    /// Gets or sets the Title of the Sale to be created.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Price of the Sale to be created.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the Description of the Sale to be created.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Category of the Sale to be created.
    /// </summary>
    public string Category { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the Image of the Sale to be created.
    /// </summary>
    public string Image { get; set; } = string.Empty;
}