﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantOrder.Domain.Core.Entities;

namespace RestaurantOrder.Services.Contracts
{
     
    public class NeededDishDto
    {
        
       
        private int value;
        public int Id { get; set; }
        public DishDto Dish { get; set; }

        public int DishQuantity
        {
            get => value;
            private set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Error");
                }
            }
        }
    }
}
