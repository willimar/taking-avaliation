using Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct;
using Ambev.DeveloperEvaluation.Application.SaleProducts.DeleteSaleProduct;
using Ambev.DeveloperEvaluation.Application.SaleProducts.GetSaleProduct;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.CreateSaleProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.DeleteSaleProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts.GetSaleProduct;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SaleProducts
{
    /// <summary>
    /// Controller for managing saleProduct operations
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class SaleProductController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of SaleProductController
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public SaleProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new saleProduct
        /// </summary>
        /// <param name="request">The saleProduct creation request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The created saleProduct details</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateSaleProductResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateSaleProduct([FromBody] CreateSaleProductRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateSaleProductCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateSaleProductResponse>
            {
                Success = true,
                Message = "SaleProduct created successfully",
                Data = _mapper.Map<CreateSaleProductResponse>(response)
            });
        }

        /// <summary>
        /// Retrieves a SaleProduct by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the saleProduct</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The SaleProduct details if found</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponseWithData<GetSaleProductResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSaleProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new GetSaleProductRequest { Id = id };
            var validator = new GetSaleProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetSaleProductCommand>(request.Id);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponseWithData<GetSaleProductResponse>
            {
                Success = true,
                Message = "SaleProduct retrieved successfully",
                Data = _mapper.Map<GetSaleProductResponse>(response)
            });
        }

        /// <summary>
        /// Deletes a SaleProduct by their ID
        /// </summary>
        /// <param name="id">The unique identifier of the SaleProduct to delete</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Success response if the SaleProduct was deleted</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSaleProduct([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var request = new DeleteSaleProductRequest { Id = id };
            var validator = new DeleteSaleProductRequestValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<DeleteSaleProductCommand>(request.Id);
            await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "SaleProduct deleted successfully"
            });
        }
    }
}
