﻿using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product in a sale
    /// </summary>
    public class SaleProduct: BaseEntity
    {
        /// <summary>
        /// The Id of the Sale
        /// </summary>
        public Guid SaleId { get; set; }

        /// <summary>
        /// The Id of the Product
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// The Name of the Product
        /// </summary>
        public string ProductName { get; set; } = string.Empty;

        /// <summary>
        /// The Value of the Product in the sale day
        /// </summary>
        public decimal UnitValue { get; set; }

        /// <summary>
        /// The discount of the product in the sale day
        /// </summary>
        public decimal Discount { get; set; }

        /// <summary>
        /// The total value of the product in the sale day
        /// </summary>
        public decimal TotalUnityValue { get; set; }

        /// <summary>
        /// If the product was canceled in the sale
        /// </summary>
        public bool Canceled { get; set; }

        /// <summary>
        /// The quantity of the product in the sale
        /// </summary>
        public int Count { get; set; }

        public Product? Product { get; set; }

        public ValidationResultDetail Validate()
        {
            var validator = new SaleProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }
    }
}
