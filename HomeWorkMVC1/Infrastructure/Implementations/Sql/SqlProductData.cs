using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeWorkMVC1.DAL.Context;
using HomeWorkMVC1.Domain.Entities;
using HomeWorkMVC1.Domain.Filters;
using HomeWorkMVC1.Entities.Base.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HomeWorkMVC1.Infrastructure.Sql
{
    public class SqlProductData : IProductData
    {
        private readonly HomeWorkMVC1Context _context;

        public SqlProductData(HomeWorkMVC1Context context)
        {
            _context = context;
        }

        public IEnumerable<Section> GetSections()
        {
            return _context.Sections.ToList();
        }

        public IEnumerable<Brand> GetBrands()
        {
            return _context.Brands.ToList();
        }

        public IEnumerable<Product> GetProducts(ProductFilter filter)
        {
            var query = _context.Products.Include("Brand").Include("Section").AsQueryable();

            if (filter.Ids != null && filter.Ids.Count > 0)
            {
                query = query.Where(c => c.Id.Equals(filter.Ids));
            }

            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue &&
                                         c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.SectionId.HasValue)
                query = query.Where(c => c.SectionId.Equals(filter.SectionId.Value));
            return query.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.Include("Brand").Include("Section").FirstOrDefault(p => p.Id.Equals(id));
        }
    }
}
