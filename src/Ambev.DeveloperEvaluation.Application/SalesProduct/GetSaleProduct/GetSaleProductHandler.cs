using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.GetSaleProduct;

/// <summary>
/// Handler for processing GetSaleProductCommand requests
/// </summary>
public class GetSaleProductHandler : IRequestHandler<GetSaleProductCommand, IEnumerable<GetSaleProductResult>>
{
    private readonly ISaleProductRepository _saleProductRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSaleProductHandler
    /// </summary>
    /// <param name="saleProductRepository">The saleProduct repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetSaleProductCommand</param>
    public GetSaleProductHandler(
        ISaleProductRepository saleProductRepository,
        IMapper mapper)
    {
        _saleProductRepository = saleProductRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSaleProductCommand request
    /// </summary>
    /// <param name="request">The GetSaleProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The saleProduct details if found</returns>
    public async Task<IEnumerable<GetSaleProductResult>> Handle(GetSaleProductCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleProductValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleProduct = await _saleProductRepository.GetBySaleIdAsync(request.Id, cancellationToken);
        if (saleProduct == null)
            throw new KeyNotFoundException($"SaleProduct with ID {request.Id} not found");

        return _mapper.Map<IEnumerable<GetSaleProductResult>>(saleProduct);
    }
}
