using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebStore.Controllers;
using WebStore.Domain.DTO.Products;
using WebStore.Domain.Entities;
using WebStore.Domain.ViewModels;
using WebStore.Interfaces.Services;
using Assert = Xunit.Assert;

namespace WebStore.Tests.Controllers
{
    [TestClass]
    public class CatalogControllerTests
    {
        [TestMethod]
        public void Details_Returns_With_Correct_View()
        {
            // A - A - A == Arrange - Act - Assert == Подготовка данных и объекта тестирования - действие над объектом - проверка утверждений

            #region Arrange

            const int expected_product_id = 1;
            const decimal expected_price = 10m;

            var expected_name = $"Product id {expected_product_id}";
            var expected_brand_name = $"Brand of product {expected_product_id}";

            var product_data_mock = new Mock<IProductData>();
            product_data_mock
               .Setup(p => p.GetProductById(It.IsAny<int>()))
               .Returns<int>(id => new ProductDTO
               {
                   Id = id,
                   Name = $"Product id {id}",
                   ImageUrl = $"Image_id_{id}.png",
                   Order = 1,
                   Price = expected_price,
                   Brand = new BrandDTO
                   {
                       Id = 1,
                       Name = $"Brand of product {id}"
                   },
                   Section = new SectionDTO
                   {
                       Id = 1,
                       Name = $"Section of product {id}"
                   }
               });

            var controller = new CatalogController(product_data_mock.Object);

            #endregion

            #region Act

            var result = controller.Details(expected_product_id);

            #endregion

            #region Assert

            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<ProductViewModel>(view_result.Model);

            Assert.Equal(expected_product_id, model.Id);
            Assert.Equal(expected_name, model.Name);
            Assert.Equal(expected_price, model.Price);
            Assert.Equal(expected_brand_name, model.Brand);

            #endregion
        }

        [TestMethod]
        public void Shop_Returns_Correct_View()
        {
            var products = new[]
            {
                new ProductDTO
                {
                    Id = 1,
                    Name = "Product 1",
                    Order = 0,
                    Price = 10m,
                    ImageUrl = "Product1.png",
                    Brand = new BrandDTO
                    {
                        Id = 1,
                        Name = "Brand of product 1"
                    },
                    Section = new SectionDTO
                    {
                        Id = 1,
                        Name = "Section of product 1"
                    }
                },
                new ProductDTO
                {
                    Id = 2,
                    Name = "Product 2",
                    Order = 0,
                    Price = 20m,
                    ImageUrl = "Product2.png",
                    Brand = new BrandDTO
                    {
                        Id = 2,
                        Name = "Brand of product 2"
                    },
                    Section = new SectionDTO
                    {
                        Id = 2,
                        Name = "Section of product 2"
                    }
                },
            };

            var product_data_mock = new Mock<IProductData>();
            product_data_mock
               .Setup(p => p.GetProducts(It.IsAny<ProductFilter>()))
               .Returns(products);

            var controller = new CatalogController(product_data_mock.Object);

            const int expected_section_id = 1;
            const int expected_brand_id = 5;

            var mapper_mock = new Mock<IMapper>();
            mapper_mock.Setup(mapper => mapper.Map<ProductViewModel>(It.IsAny<ProductDTO>()))
               .Returns<ProductDTO>(p => new ProductViewModel
               {
                   Id = p.Id,
                   Name = p.Name,
                   Order = p.Order,
                   Price = p.Price,
                   Brand = p.Brand?.Name,
                   ImageUrl = p.ImageUrl
               });


            var result = controller.Shop(expected_section_id, expected_brand_id, mapper_mock.Object);

            var view_result = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<CatalogViewModel>(view_result.ViewData.Model);

            Assert.Equal(products.Length, model.Products.Count());
            Assert.Equal(expected_brand_id, model.BrandId);
            Assert.Equal(expected_section_id, model.SectionId);

            //Assert.Equal(products[0].Brand.Name, actual_products[0].Brand);
        }
    }
}
