﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.SaleProducts.CreateSaleProduct
{
    public class CreateSaleProductNotification: INotification
    {
        public SaleProduct? SaleProduct { get; set; }
    }
}
