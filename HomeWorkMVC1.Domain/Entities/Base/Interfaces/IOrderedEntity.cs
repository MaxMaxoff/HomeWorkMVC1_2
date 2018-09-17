namespace HomeWorkMVC1.Domain.Models.Base
{
    /// <summary>
    /// Entity with order
    /// </summary>
    public interface IOrderedEntity : INamedEntity
    {
        /// <summary>
        /// Order
        /// </summary>
        int Order { get; set; }
    }
}
