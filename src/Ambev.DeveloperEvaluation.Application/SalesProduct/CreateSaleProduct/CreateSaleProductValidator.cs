﻿using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct;

/// <summary>
/// Validator for CreateSaleProductCommand that defines validation rules for saleProduct creation.
/// </summary>
public class CreateSaleProductCommandValidator : AbstractValidator<CreateSaleProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleProductCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// SaleId is required and must be a valid GUID.
    /// ProductId is required and must be a valid GUID.
    /// Count is required and must be greater than 0.
    /// </remarks>
    public CreateSaleProductCommandValidator()
    {
        RuleFor(sale => sale.SaleId).Must(id => id != Guid.Empty);
        RuleFor(sale => sale.ProductId).Must(id => id != Guid.Empty);

        RuleFor(sale => sale.Count).GreaterThan(0);
    }
}