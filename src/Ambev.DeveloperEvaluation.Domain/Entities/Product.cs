using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a Product in the system with information.
    /// This entity follows domain-driven design principles and includes business rules validation.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets the Title of the Product.
        /// Must not be null or empty and should contain a descriptive name.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Gets the Price of the Product.
        /// Must be greater than zero.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets the Description of the Product.
        /// Must not be null or empty and should contain a description of the product.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets the Category of the Product.
        /// Must not be null or empty and should contain a category for the product.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets the Image of the Product.
        /// Must not be null or empty and should contain a URL for the product image.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
