﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using RestaurantOrder.Domain.Core.Entities;
namespace RestaurantOrder.Services.Contracts
{
    public class ProductDto

    {
        public int Id { get; set; }
         public string  Name { get; set; }
         public int Quantity { get; set; }

         
    }

    
}