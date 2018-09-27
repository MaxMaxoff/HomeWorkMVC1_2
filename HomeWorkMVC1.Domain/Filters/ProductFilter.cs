using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWorkMVC1.Domain.Filters
{
    /// <summary>
    /// Public Class Product Filter
    /// </summary>
    public class ProductFilter
    {
        /// <summary>
        /// Section if exist
        /// </summary>
        public int? SectionId { get; set; }

        /// <summary>
        /// Barnd if exist
        /// </summary>
        public int? BrandId { get; set; }

        public List<int> Ids { get; set; }
    }
}
