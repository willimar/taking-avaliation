using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, length between 3 and 100 characters
    /// - Description: Required, length between 3 and 250 characters
    /// - Category: Required, length between 3 and 100 characters
    /// - Image: Must match with the valid URL format (using UrlValidator)
    /// - Price: Cannot be less than or equal to 0
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.Title).NotEmpty().Length(3, 100);
        RuleFor(sale => sale.Description).NotEmpty().Length(3, 250);
        RuleFor(sale => sale.Category).NotEmpty().Length(3, 100);
        
        RuleFor(sale => sale.Price).GreaterThan(0);

        RuleFor(user => user.Image).SetValidator(new UrlValidator());
    }
}