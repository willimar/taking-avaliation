using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct;

/// <summary>
/// Handler for processing CreateSaleProductCommand requests
/// </summary>
public class CreateSaleProductHandler : IRequestHandler<CreateSaleProductCommand, CreateSaleProductResult>
{
    private readonly ISaleProductRepository _saleProductRepository;
    private readonly IMapper _mapper;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of CreateSaleProductHandler
    /// </summary>
    /// <param name="SaleProductRepository">The SaleProduct repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleProductCommand</param>
    public CreateSaleProductHandler(ISaleProductRepository SaleProductRepository, IMapper mapper, IPasswordHasher passwordHasher, IMediator mediator)
    {
        _saleProductRepository = SaleProductRepository;
        _mapper = mapper;
        _passwordHasher = passwordHasher;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the CreateSaleProductCommand request
    /// </summary>
    /// <param name="command">The CreateSaleProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created SaleProduct details</returns>
    public async Task<CreateSaleProductResult> Handle(CreateSaleProductCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleProductCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var saleProduct = _mapper.Map<SaleProduct>(command);

        var createdSaleProduct = await _saleProductRepository.CreateAsync(saleProduct, cancellationToken);
        var result = _mapper.Map<CreateSaleProductResult>(createdSaleProduct);

        await _mediator.Send(new CreateSaleProductNotification { SaleProduct = createdSaleProduct }, cancellationToken);

        return result;
    }
}
