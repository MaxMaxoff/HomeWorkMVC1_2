using System.Collections.Generic;

namespace HomeWorkMVC1.Models.Product
{
    /// <summary>
    /// 
    /// </summary>
    public class CatalogViewModel
    {
        public int? BrandId { get; set; }
        public int? SectionId { get; set; }

        public IEnumerable<ProductViewModel> Products { get; set; }
    }
}
