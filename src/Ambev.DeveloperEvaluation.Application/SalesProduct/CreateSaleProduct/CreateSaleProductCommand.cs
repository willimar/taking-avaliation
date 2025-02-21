using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Enums;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct;

/// <summary>
/// Command for creating a new SaleProduct.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a SaleProduct, 
/// including SaleProductname, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSaleProductResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleProductCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleProductCommand : IRequest<CreateSaleProductResult>
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
    /// The quantity of the product in the sale
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Validates the data provided in the command.
    /// </summary>
    /// <returns></returns>
    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleProductCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}