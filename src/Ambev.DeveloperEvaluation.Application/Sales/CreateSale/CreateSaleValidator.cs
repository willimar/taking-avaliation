using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for sale creation.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// CustomerName is required and must be between 3 and 100 characters.
    /// CpfCnpjCustomer is required and must be a valid CPF or CNPJ.
    /// CompanyName is required and must be between 1 and 100 characters.
    /// UserName is required and must be between 1 and 50 characters.
    /// </remarks>
    public CreateSaleCommandValidator()
    {
        RuleFor(sale => sale.CustomerName).NotEmpty().Length(3, 100);
        RuleFor(sale => sale.CpfCnpjCustomer).NotEmpty().SetValidator(new CpfCnpjValidator());
        RuleFor(sale => sale.CompanyName).NotEmpty().Length(1, 100);
        RuleFor(sale => sale.UserName).NotEmpty().Length(1, 50);
    }
}