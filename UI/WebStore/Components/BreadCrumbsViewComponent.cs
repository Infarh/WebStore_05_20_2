using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;

namespace WebStore.Components
{
    public class BreadCrumbsViewComponent : ViewComponent
    {
        private readonly IProductData _ProductData;

        public BreadCrumbsViewComponent(IProductData ProductData) => _ProductData = ProductData;

        public IViewComponentResult Invoke()
        {
            var model = new BreadCrumbViewModel();

            if (int.TryParse(Request.Query["SectionId"].ToString(), out var section_id)) 
                model.Section = _ProductData.GetSection(section_id);

            if (int.TryParse(Request.Query["BrandId"].ToString(), out var brand_id)) 
                model.Brand = _ProductData.GetBrand(brand_id);

            if (int.TryParse(ViewContext.RouteData.Values["id"]?.ToString(), out var product_id))
            {
                var product = _ProductData.GetProductById(product_id);
                if (product != null)
                    model.Product = product.Name;
;            }

            return View(model);
        }
    }
}
