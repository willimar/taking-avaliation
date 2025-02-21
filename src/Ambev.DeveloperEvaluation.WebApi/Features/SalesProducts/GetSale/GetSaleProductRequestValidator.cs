using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.GetSaleProduct;

/// <summary>
/// Validator for GetSaleProductRequest
/// </summary>
public class GetSaleProductRequestValidator : AbstractValidator<GetSaleProductRequest>
{
    /// <summary>
    /// Initializes validation rules for GetSaleProductRequest
    /// </summary>
    public GetSaleProductRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleProduct ID is required");
    }
}
