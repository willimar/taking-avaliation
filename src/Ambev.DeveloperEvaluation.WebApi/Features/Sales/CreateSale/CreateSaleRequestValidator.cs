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
    /// Initializes validation rules for CreateSaleRequest
    /// </summary>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.CustomerName).NotEmpty().Length(3, 100);
        RuleFor(sale => sale.CpfCnpjCustomer).NotEmpty().SetValidator(new CpfCnpjValidator());
        RuleFor(sale => sale.CompanyName).NotEmpty().Length(1, 100);
        RuleFor(sale => sale.UserName).NotEmpty().Length(1, 50);
    }
}