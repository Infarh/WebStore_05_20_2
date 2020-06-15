using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.Infrastructure.Mapping;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductData _ProductData;

        public CatalogController(IProductData ProductData) => _ProductData = ProductData;

        public IActionResult Shop(int? SectionId, int? BrandId)
        {
            var filter = new ProductFilter
            {
                SectionId = SectionId,
                BrandId = BrandId
            };

            var products = _ProductData.GetProducts(filter);

            return View(new CatalogViewModel
            {
                SectionId = SectionId,
                BrandId = BrandId,
                Products = products
                   .ToView()
                   .OrderBy(p => p.Order)
            });
        }
    }
}
