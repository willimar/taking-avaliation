using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a Sale in the system.
    /// </summary>
    public class Sale : BaseEntity
    {
        /// <summary>
        /// Gets or sets the Sale Number.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Gets or sets the Sale Date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the Customer Name.
        /// </summary>
        public string CustomerName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Customer CPF/CNPJ.
        /// </summary>
        public string CpfCnpjCustomer { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Company Name.
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the User Name.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Total Value of the Sale.
        /// </summary>
        public decimal TotalValue { get; set; }

        /// <summary>
        /// Gets or sets the Sale Status.
        /// </summary>
        public SaleStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the Products of the Sale.
        /// </summary>
        public ICollection<SaleProduct> Products { get; set; } = [];

        public ValidationResultDetail Validate()
        {
            var validator = new SaleValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
