using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.DeleteSaleProduct;

/// <summary>
/// Handler for processing DeletesaleProductCommand requests
/// </summary>
public class DeleteSaleProductHandler : IRequestHandler<DeleteSaleProductCommand, DeleteSaleProductResponse>
{
    private readonly ISaleProductRepository _saleProductRepository;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of DeletesaleProductHandler
    /// </summary>
    /// <param name="saleProductRepository">The saleProduct repository</param>
    /// <param name="validator">The validator for DeletesaleProductCommand</param>
    public DeleteSaleProductHandler(ISaleProductRepository saleProductRepository, IMediator mediator)
    {
        _saleProductRepository = saleProductRepository;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the DeletesaleProductCommand request
    /// </summary>
    /// <param name="request">The DeletesaleProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleProductResponse> Handle(DeleteSaleProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var removedSaleProduct = await _saleProductRepository.DeleteAsync(request.Id, cancellationToken);

        await _mediator.Publish(new CreateSaleProductNotification { SaleProduct = removedSaleProduct }, cancellationToken);

        if (removedSaleProduct is null)
            throw new KeyNotFoundException($"saleProduct with ID {request.Id} not found");

        return new DeleteSaleProductResponse { Success = true };
    }
}
