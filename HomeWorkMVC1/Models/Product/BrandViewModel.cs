using HomeWorkMVC1.Domain.Models.Base;

namespace HomeWorkMVC1.Models.Product
{
    public class BrandViewModel : INamedEntity, IOrderedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Qty products of Brand
        /// </summary>
        public int ProductsCount { get; set; }

        public int Order { get; set; }
    }
}
