using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct
{
    /// <summary>
    /// Event for creating a new SaleProduct.
    /// </summary>
    public class CreateSaleProductEvent : INotificationHandler<CreateSaleProductNotification>
    {
        private readonly ILogger _logger;
        private readonly ISaleProductRepository _saleProductRepository;
        private readonly ISaleRepository _saleRepository;

        /// <summary>
        /// Initializes a new instance of CreateSaleProductEvent.
        /// </summary>
        /// <param name="logger"></param>
        public CreateSaleProductEvent(ILogger<CreateSaleProductEvent> logger, ISaleProductRepository saleProductRepository, ISaleRepository saleRepository)
        {
            _logger = logger;
            _saleProductRepository = saleProductRepository;
            _saleRepository = saleRepository;
        }

        /// <summary>
        /// Implement create saleProduct domain code notification.
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateSaleProductNotification notification, CancellationToken cancellationToken)
        {
            if (notification.SaleProduct is null)
            {
                _logger.LogError("Product Sale not found");
                return;
            }

            // Normalmente este tipo de processamento seria executado de forma assincrona, mas para simplificar o exemplo, foi mantido de forma sincrona.
            var totalValue = await _saleProductRepository.GetTotalBySaleIdAsync(notification.SaleProduct!.SaleId, cancellationToken);
            var sale = await _saleRepository.GetByIdAsync(notification.SaleProduct.SaleId, cancellationToken);

            if (sale == null)
            {
                _logger.LogError("Sale not found");
                return;
            }

            sale.TotalValue = totalValue;
            sale.Status = SaleStatus.Modified;

            await _saleRepository.UpdateAsync(sale, cancellationToken);
        }
    }
}
