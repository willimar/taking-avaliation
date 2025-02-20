using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductRequest that defines validation rules for product creation.
/// </summary>
public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Title: Required, length between 3 and 100 characters
    /// - Description: Required, length between 3 and 250 characters
    /// - Category: Required, length between 3 and 100 characters
    /// - Image: Must match with the valid URL format (using UrlValidator)
    /// - Price: Cannot be less than or equal to 0
    /// </remarks>
    public CreateProductRequestValidator()
    {
        RuleFor(product => product.Title).NotEmpty().Length(3, 100);
        RuleFor(product => product.Description).NotEmpty().Length(3, 250);
        RuleFor(product => product.Category).NotEmpty().Length(3, 100);
        
        RuleFor(product => product.Price).GreaterThan(0);

        RuleFor(user => user.Image).SetValidator(new UrlValidator());
    }
}