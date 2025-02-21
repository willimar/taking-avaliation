using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Sale : BaseEntity
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public string CpfCnpjCustomer { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;

        public decimal TotalValue { get; set; }

        public SaleStatus Status { get; set; }

        public ICollection<SaleProduct> Products { get; set; } = [];
    }
}
