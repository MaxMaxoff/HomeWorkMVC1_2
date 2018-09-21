using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using HomeWorkMVC1.Domain.Entities;

namespace HomeWorkMVC1.DAL.Context
{
    public class HomeWorkMVC1Context : DbContext
    {
        public HomeWorkMVC1Context(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Section> Sections { get; set; }

        public DbSet<Brand> Brands { get; set; }

    }
}
