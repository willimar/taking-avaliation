using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.DeleteSaleProduct;

/// <summary>
/// Validator for DeleteSaleProductCommand
/// </summary>
public class DeleteSaleProductValidator : AbstractValidator<DeleteSaleProductCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteSaleProductCommand
    /// </summary>
    public DeleteSaleProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleProduct ID is required");
    }
}
