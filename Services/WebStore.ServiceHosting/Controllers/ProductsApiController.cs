using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route(WebAPI.Products)]
    [ApiController]
    public class ProductsApiController : ControllerBase, IProductData
    {
        private readonly IProductData _ProductData;

        public ProductsApiController(IProductData ProductData) => _ProductData = ProductData;

        [HttpGet("sections")] //api/products/sections
        public IEnumerable<Section> GetSections() => _ProductData.GetSections();

        [HttpGet("section/{Id}")]
        public Section GetSection(int Id) => _ProductData.GetSection(Id);

        [HttpGet("brands")] //api/products/brands
        public IEnumerable<Brand> GetBrands() => _ProductData.GetBrands();

        [HttpGet("brand/{Id}")]
        public Brand GetBrand(int Id) => _ProductData.GetBrand(Id);

        [HttpPost]
        public PageProductsDTO GetProducts([FromBody] ProductFilter Filter = null) => _ProductData.GetProducts(Filter);

        [HttpGet("{id}")]
        public ProductDTO GetProductById(int id) => _ProductData.GetProductById(id);
    }
}
