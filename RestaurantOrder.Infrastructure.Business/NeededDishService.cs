﻿using System.Collections.Generic;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Infrastructure.Business
{
    public class NeededDishService : INeededDishService
    {
        private readonly INeededDishRepository repository;
        public NeededDishService(INeededDishRepository neededDishRepository)
        {
            this.repository = neededDishRepository;
        }

        public NeededDish Create(NeededDish neededDish)
        {
            return repository.Create(neededDish);
        }

        public NeededDish GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Delete(int id)
        { 
            repository.Delete(id);
        }

        public ICollection<NeededDish> GetAll()
        {
            return repository.GetAll();
        }
    }
}
