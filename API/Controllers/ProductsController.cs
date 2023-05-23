using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        public ProductsController(IGenericRepository<Product> productRepo)
        {
            _productRepo= productRepo;
        }
        
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts()
        {
           //var products= await _productRepo.GetAllAsync();
           var spec = new ProductsWithTypesAndBrandsSpecification();
           var products = await _productRepo.GetAllWithSpecAsync(spec);
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            //var product = await _productRepo.GetByIdAsync(id);
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productRepo.GetByIdWithSpecAsync(spec);
            return Ok(product);
        }
    }
}
