using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HomeWorkMVC1.Domain.Models.Base;

namespace HomeWorkMVC1.Domain.Entities
{
    /// <inheritdoc cref="NamedEntity" />
    /// <summary>
    /// Public Class Section
    /// </summary>
    public class Section : NamedEntity, IOrderedEntity
    {
        /// <summary>
        /// Parent Section if exist
        /// </summary>
        public int? ParentId { get; set; }

        [ForeignKey("ParentId")]
        public virtual Section ParentSection { get; set; }

        public int Order { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
