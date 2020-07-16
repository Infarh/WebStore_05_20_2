using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;
using WebStore.Services.Mapping;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private const string __PageSize = "PageSize";

        private readonly IProductData _ProductData;
        private readonly IConfiguration _Configuration;

        public CatalogController(IProductData ProductData, IConfiguration Configuration)
        {
            _ProductData = ProductData;
            _Configuration = Configuration;
        }

        public IActionResult Shop(int? SectionId, int? BrandId, [FromServices] IMapper Mapper, int Page = 1)
        {
            var page_size = int.TryParse(_Configuration[__PageSize], out var size)
                ? size
                : (int?) null;

            var filter = new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Page = Page,
                PageSize = page_size
            };

            var products = _ProductData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products = products
                   .Products
                   .Select(p => p.FromDTO())
                   .Select(Mapper.Map<ProductViewModel>)
                   .OrderBy(p => p.Order),
                PageViewModel = new PageViewModel
                {
                    PageSize = page_size ?? 0,
                    PageNumber = Page,
                    TotalItems = products.TotalCount
                }
            });
        }

        public IActionResult Details(int id)
        {
            var product = _ProductData.GetProductById(id);

            if (product is null)
                return NotFound();

            return View(product.FromDTO().ToView());
        }

        #region WebAPI

        public IActionResult GetCatalogHtml(int? SectionId, int? BrandId, int Page, [FromServices] IMapper Mapper) => 
            PartialView("Partial/_FeaturesItems", GetProducts(SectionId, BrandId, Page, Mapper));

        private IEnumerable<ProductViewModel> GetProducts(int? SectionId, int? BrandId, int Page, IMapper Mapper) =>
            _ProductData.GetProducts(new ProductFilter
                {
                    SectionId = SectionId,
                    BrandId = BrandId,
                    Page = Page,
                    PageSize = int.Parse(_Configuration[__PageSize])
                })
               .Products
               .Select(ProductMapper.FromDTO)
               .Select(ProductMapper.ToView)
               .OrderBy(p => p.Order);

        #endregion
    }
}
