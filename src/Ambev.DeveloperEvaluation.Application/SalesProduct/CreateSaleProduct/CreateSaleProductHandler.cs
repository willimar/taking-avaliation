using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Common.Security;
using System.Threading;
using Microsoft.Extensions.Logging;
using Serilog.Core;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct;

/// <summary>
/// Handler for processing CreateSaleProductCommand requests
/// </summary>
public class CreateSaleProductHandler : IRequestHandler<CreateSaleProductCommand, CreateSaleProductResult>
{
    private readonly ISaleProductRepository _saleProductRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of CreateSaleProductHandler
    /// </summary>
    /// <param name="SaleProductRepository">The SaleProduct repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleProductCommand</param>
    public CreateSaleProductHandler(ISaleProductRepository SaleProductRepository, IProductRepository productRepository, IMapper mapper, IPasswordHasher passwordHasher, IMediator mediator, ILogger<CreateSaleProductHandler> logger)
    {
        _saleProductRepository = SaleProductRepository;
        _productRepository = productRepository;
        _mapper = mapper;
        _mediator = mediator;
        _logger = logger;
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

        SaleProduct? saleProduct = await _saleProductRepository.GetByIdAsync(command.ProductId, command.SaleId, cancellationToken);
        var createNew = false;

        if (saleProduct == null)
        {
            saleProduct = _mapper.Map<SaleProduct>(command);
            createNew = true;
        }
        else
        {
            saleProduct.Count = command.Count;
        }

        var (productName, unitValue) = await GetUnitValue(saleProduct.ProductId, cancellationToken);

        saleProduct.UnitValue = unitValue;
        saleProduct.ProductName = productName;
        saleProduct.Discount = CalculateDiscountValue(saleProduct.Count, saleProduct.UnitValue);
        saleProduct.TotalUnityValue = saleProduct.UnitValue - saleProduct.Discount;

        
        var createdSaleProduct = createNew ? 
            await _saleProductRepository.CreateAsync(saleProduct, cancellationToken) : 
            await _saleProductRepository.UpdateAsync(saleProduct, cancellationToken);

        var result = _mapper.Map<CreateSaleProductResult>(createdSaleProduct);

        await _mediator.Publish(new CreateSaleProductNotification { SaleProduct = createdSaleProduct }, cancellationToken);

        return result;
    }

    private async Task<(string productName, decimal unitValue)> GetUnitValue(Guid productId, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetByIdAsync(productId, cancellationToken);

        if (product == null)
        {
            _logger.LogError("Product not found");
            return ("", 0.0M);
        }

        return (product.Title, product.Price);
    }

    private decimal CalculateDiscountValue(int count, decimal unitValue)
    {
        var result = 0M;

        if (count >= 4 && count < 10)
        {
            result = unitValue * 0.1M;
        }

        if (count >= 10 && count <= 20)
        {
            result = unitValue * 0.2M;
        }

        return result;
    }
}
