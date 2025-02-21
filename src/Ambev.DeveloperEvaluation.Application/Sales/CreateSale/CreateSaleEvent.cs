using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    /// <summary>
    /// Event for creating a new Sale.
    /// </summary>
    public class CreateSaleEvent : INotificationHandler<CreateSaleNotification>
    {
        private readonly ILogger _logger;

        /// <summary>
        /// Initializes a new instance of CreateSaleEvent.
        /// </summary>
        /// <param name="logger"></param>
        public CreateSaleEvent(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Implement create sale domain code notification.
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(CreateSaleNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sale created: {Sale}", notification.Sale);
            await Task.CompletedTask;
        }
    }
}
