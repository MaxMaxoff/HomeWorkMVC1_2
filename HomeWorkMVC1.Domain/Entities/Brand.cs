using HomeWorkMVC1.Domain.Models.Base;

namespace HomeWorkMVC1.Domain.Entities
{
    /// <inheritdoc cref="NamedEntity" />
    /// <summary>
    /// Public Class Brand
    /// </summary>
    public class Brand : NamedEntity, IOrderedEntity
    {
        public int Order { get; set; }
    }

}
