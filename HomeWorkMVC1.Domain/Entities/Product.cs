using System.ComponentModel.DataAnnotations.Schema;
using HomeWorkMVC1.Domain.Models.Base;

namespace HomeWorkMVC1.Domain.Entities
{
    /// <inheritdoc cref="NamedEntity" />
    /// <summary>
    /// Class Product
    /// </summary>
    public class Product : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }

        /// <summary>
        /// Section
        /// </summary>
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public virtual Section Section { get; set; }

        /// <summary>
        /// Brand
        /// </summary>
        public int? BrandId { get; set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        /// <summary>
        /// Image ref
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; set; }
    }
}
