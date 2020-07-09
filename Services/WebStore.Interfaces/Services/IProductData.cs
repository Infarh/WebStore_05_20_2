using System.Collections.Generic;
using System.Linq;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;

namespace WebStore.Interfaces.Services
{
    public interface IProductData
    {
        IEnumerable<Section> GetSections();

        Section GetSection(int Id);

        IEnumerable<Brand> GetBrands();

        Brand GetBrand(int Id);// => GetBrands().FirstOrDefault(b => b.Id == Id);

        IEnumerable<ProductDTO> GetProducts(ProductFilter Filter = null);

        ProductDTO GetProductById(int id);
    }
}
