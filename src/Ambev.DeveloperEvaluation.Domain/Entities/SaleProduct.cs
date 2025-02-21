using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class SaleProduct: BaseEntity
    {
        public string ProductName { get; set; } = string.Empty;

        public decimal UnitValue { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalUnityValue { get; set; }

        public bool Canceled { get; set; }

        public int Count { get; set; }
    }
}
