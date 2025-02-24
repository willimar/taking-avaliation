using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    /// <summary>
    /// Validator for Sale that defines validation rules for sale creation.
    /// </summary>
    public class SaleValidator : AbstractValidator<Sale>
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
        public SaleValidator()
        {
            RuleFor(sale => sale.Number).NotEmpty();
            RuleFor(sale => sale.CustomerName).NotEmpty().Length(3, 100);
            RuleFor(sale => sale.CpfCnpjCustomer).NotEmpty().SetValidator(new CpfCnpjValidator());
            RuleFor(sale => sale.CompanyName).NotEmpty().Length(1, 100);
            RuleFor(sale => sale.UserName).NotEmpty().Length(1, 50);
        }
    }
}
