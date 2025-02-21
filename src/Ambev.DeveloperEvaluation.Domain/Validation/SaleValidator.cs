using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.CustomerName).NotEmpty().Length(3, 100);
            RuleFor(sale => sale.CpfCnpjCustomer).NotEmpty().SetValidator(new CpfCnpjValidator());
            RuleFor(sale => sale.CompanyName).NotEmpty().Length(1, 100);
            RuleFor(sale => sale.UserName).NotEmpty().Length(1, 50);
        }
    }
}
