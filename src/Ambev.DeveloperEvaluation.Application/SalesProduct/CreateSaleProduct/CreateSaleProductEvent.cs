using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct
{
    /// <summary>
    /// Event for creating a new SaleProduct.
    /// </summary>
    public class CreateSaleProductEvent : INotificationHandler<CreateSaleProductNotification>
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of CreateSaleProductEvent.
        /// </summary>
        /// <param name="logger"></param>
        public CreateSaleProductEvent(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Implement create saleProduct domain code notification.
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateSaleProductNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("SaleProduct created: {SaleProduct}", notification.SaleProduct);
            await Task.CompletedTask;
        }
    }
}
