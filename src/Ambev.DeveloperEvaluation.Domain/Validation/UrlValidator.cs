using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class UrlValidator : AbstractValidator<string>
    {
        public UrlValidator()
        {
            RuleFor(email => email)
                .NotEmpty()
                .WithMessage("The url image address cannot be empty.")
                .MaximumLength(1000)
                .WithMessage("The url address cannot be longer than 1000 characters.")
                .Must(BeValidUrl)
                .WithMessage("The provided url address is not valid.");
        }

        private bool BeValidUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return false;

            var regex = new Regex(@"^(https?://)(www\.)?([a-zA-Z0-9.-]+)\.([a-zA-Z]{2,})(/.*)?$");

            return regex.IsMatch(url);
        }
    }
}
