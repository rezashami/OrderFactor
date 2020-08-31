using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Simulation.Data;
using Simulation.Dto;
using Simulation.Models;

namespace Simulation.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductsController :ControllerBase{
        public ProductsController(IProductRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        private readonly IProductRepo _repository;
        private readonly IMapper _mapper;
        [HttpGet]
        public ActionResult <IEnumerable<Product>> GetAllProducts(){
            var productItems = _repository.GetAllProducts();
            return Ok(productItems);
        }
        [HttpGet("{id}",Name="GetProductById")]
        public ActionResult <Product> GetProductById(int id){
            var productItem = _repository.GetProductById(id);
            if(productItem != null)
            {
                return Ok(productItem);
            }
            return NotFound();
        }
        [HttpPost]
        public ActionResult <Product> CreateProduct(Product product)
        {
            _repository.CreateProduct(product);
            _repository.SaveChanges();
            return CreatedAtRoute("GetProductById", new {Id = product.Id}, product);      
        }
    }
}