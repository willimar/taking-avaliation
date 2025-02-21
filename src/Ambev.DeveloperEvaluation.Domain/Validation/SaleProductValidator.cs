using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleProductValidator : AbstractValidator<SaleProduct>
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
        public SaleProductValidator()
        {
            RuleFor(sale => sale.SaleId).Must(id => id != Guid.Empty);
            RuleFor(sale => sale.ProductId).Must(id => id != Guid.Empty);

            RuleFor(sale => sale.ProductName).NotEmpty().Length(1, 100);
            RuleFor(sale => sale.UnitValue).GreaterThan(0);
            RuleFor(sale => sale.Discount).GreaterThanOrEqualTo(0);
            RuleFor(sale => sale.TotalUnityValue).GreaterThan(0);

            RuleFor(sale => sale.Count).GreaterThan(0);
        }
    }
}
