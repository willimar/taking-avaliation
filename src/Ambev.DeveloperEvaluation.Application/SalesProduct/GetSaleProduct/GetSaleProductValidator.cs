using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.GetSaleProduct;

/// <summary>
/// Validator for GetSaleProductCommand
/// </summary>
public class GetSaleProductValidator : AbstractValidator<GetSaleProductCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSaleProductCommand
    /// </summary>
    public GetSaleProductValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleProduct ID is required");
    }
}
