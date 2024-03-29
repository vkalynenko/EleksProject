﻿using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using RestaurantOrder.Domain.Core.Entities;
using RestaurantOrder.Services.Contracts;
using RestaurantOrder.Services.Interfaces;

namespace RestaurantOrder.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        private readonly INeededProductService _neededProductService;
        private readonly IDishService _dishService;

        public ProductController(IMapper mapper, IProductService productService, INeededProductService neededProductService, IDishService dishService)
        {
            _mapper = mapper;
            _productService = productService;
            _neededProductService = neededProductService;
            _dishService = dishService;
            

        }
        
        [HttpPost]
        public IActionResult CreateProduct(ProductDto product)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _productService.CreateProduct(_mapper.Map<Product>(product));
            return RedirectToAction("CreateProduct", "Product");
        }


        [HttpGet]
        public IActionResult CreateProduct()
        {

            return View();
        }

        [HttpGet]
        public ActionResult<Product> GetAll(int id)
        {
            
            ViewBag.DishId = id;
            
            return View(_productService.GetAll());
        }

        [HttpGet]
        public IActionResult DeleteProduct()
        {

            return View(_productService.GetAll());

        }

        [HttpPost]
        public ActionResult <Product> DeleteProduct(int id)
        {
            try
            {
                _productService.DeleteProduct(id);
                return RedirectToAction("DeleteProduct", "Product");
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        public IActionResult AddProductToList(int productId, int neededDishId, int quantity)
        {
            var product = _productService.GetProductById(productId);
            var dish = _dishService.GetDishById(neededDishId);

            var neededProduct = new NeededProduct
            {
                Product = product,
                ProductQuantity = quantity,
            };
            if (neededProduct.ProductQuantity != 0)
            {
                dish.NeededProducts.Add(neededProduct);
                _neededProductService.Create(neededProduct);

                _dishService.Update(dish);
                return RedirectToAction("GetAll", new {id = neededDishId});

            }
            return RedirectToAction("GetAll", new { id = neededDishId });

        }
        
        



    }
}
