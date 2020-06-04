using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;

namespace WebStore.Data
{
    public class WebStoreDBInitializer
    {
        private readonly WebStoreDB _db;
        public WebStoreDBInitializer(WebStoreDB db) => _db = db;

        public void Initialize()
        {
            var db = _db.Database;

            //if(db.EnsureDeleted())
            //    if(!db.EnsureCreated())
            //        throw new InvalidOperationException("Ошибка при создании базы данных товаров");

            db.Migrate();
            
            if(_db.Products.Any()) return;

            using (db.BeginTransaction())
            {
                _db.Sections.AddRange(TestData.Sections);

                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSection] ON");
                _db.SaveChanges();
                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductSection] OFF");

                db.CommitTransaction();
            }

            using (var transaction = db.BeginTransaction())
            {
                _db.Brands.AddRange(TestData.Brands);

                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrand] ON");
                _db.SaveChanges();
                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ProductBrand] OFF");

                transaction.Commit();
            }

            using (var transaction = db.BeginTransaction())
            {
                _db.Products.AddRange(TestData.Products);


                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] ON");
                _db.SaveChanges();
                db.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[Products] OFF");

                transaction.Commit();
            }
        }
    }
}
