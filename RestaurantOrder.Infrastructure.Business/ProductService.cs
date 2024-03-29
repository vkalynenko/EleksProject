﻿using System.Collections.Generic;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Domain.Interfaces;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Infrastructure.Business
{
    
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;

        public ProductService(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }
        public Product CreateProduct(Product product)
        {
            return repository.Create(product);
        }

        public Product GetProductById(int id)
        {
            return repository.GetById(id);
        }

        public ICollection<Product> GetAll()
        {
            return repository.GetAll();
        }

        public void DeleteProduct(int id)
        {
            repository.Delete(id);
        }
    }
}
