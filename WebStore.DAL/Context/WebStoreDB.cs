using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebStore.Domain.Entities;
using WebStore.Domain.Entities.Employees;
using WebStore.Domain.Entities.Identity;

namespace WebStore.DAL.Context
{
    public class WebStoreDB : IdentityDbContext<User, Role, string>
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<Employee> Employees { get; set; }
        
        public WebStoreDB(DbContextOptions<WebStoreDB> Options) : base(Options) { }
    }
}
