using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository ProductRepository;
        public ProductsController(ProductRepository productRepository)
        {
            this.ProductRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await this.ProductRepository.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await this.ProductRepository.GetProductByIdAsync(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            var productBrands = await this.ProductRepository.GetProductBrandsAsync();
            return Ok(productBrands);
        }

        [HttpGet]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            var productTypes = await this.ProductRepository.GetProductTypesAsync();
            return Ok(productTypes);
        }
    }
}