using Microsoft.EntityFrameworkCore;
using HomeWorkMVC1.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HomeWorkMVC1.DAL.Context
{
    public class HomeWorkMVC1Context : IdentityDbContext<User>
    {
        public HomeWorkMVC1Context(DbContextOptions options) : base(options)
        {}

        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Order> Orders { get; set; }

    }
}
