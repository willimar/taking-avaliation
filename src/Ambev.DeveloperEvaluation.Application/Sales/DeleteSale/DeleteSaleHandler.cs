using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler for processing DeletesaleCommand requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    /// Initializes a new instance of DeletesaleHandler
    /// </summary>
    /// <param name="saleRepository">The sale repository</param>
    /// <param name="validator">The validator for DeletesaleCommand</param>
    public DeleteSaleHandler(
        ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    /// <summary>
    /// Handles the DeletesaleCommand request
    /// </summary>
    /// <param name="request">The Deletesale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _saleRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"sale with ID {request.Id} not found");

        return new DeleteSaleResponse { Success = true };
    }
}
