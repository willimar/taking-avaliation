using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.DeleteSaleProduct;

/// <summary>
/// Validator for DeleteSaleProductRequest
/// </summary>
public class DeleteSaleProductRequestValidator : AbstractValidator<DeleteSaleProductRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteSaleProductRequest
    /// </summary>
    public DeleteSaleProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleProduct ID is required");
    }
}
