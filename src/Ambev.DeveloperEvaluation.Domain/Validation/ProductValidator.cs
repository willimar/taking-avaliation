using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(user => user.Image).SetValidator(new UrlValidator());

            RuleFor(user => user.Title)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Title must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Title cannot be longer than 100 characters.");

            RuleFor(user => user.Description)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Description must be at least 3 characters long.")
                .MaximumLength(250).WithMessage("Description cannot be longer than 250 characters.");

            RuleFor(user => user.Category)
                .NotEmpty()
                .MinimumLength(3).WithMessage("Category must be at least 3 characters long.")
                .MaximumLength(250).WithMessage("Category cannot be longer than 100 characters.");

            RuleFor(user => user.Price)
                .GreaterThan(0);
        }
    }
}
