using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Products.DeleteProduct;

/// <summary>
/// Handler for processing DeleteproductCommand requests
/// </summary>
public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, DeleteProductResponse>
{
    private readonly IProductRepository _productRepository;

    /// <summary>
    /// Initializes a new instance of DeleteproductHandler
    /// </summary>
    /// <param name="productRepository">The product repository</param>
    /// <param name="validator">The validator for DeleteproductCommand</param>
    public DeleteProductHandler(
        IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    /// <summary>
    /// Handles the DeleteproductCommand request
    /// </summary>
    /// <param name="request">The Deleteproduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _productRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"product with ID {request.Id} not found");

        return new DeleteProductResponse { Success = true };
    }
}
