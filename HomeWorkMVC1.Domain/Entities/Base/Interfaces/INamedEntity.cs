namespace HomeWorkMVC1.Domain.Models.Base
{
    /// <inheritdoc />
    /// <summary>
    /// Entity with name
    /// </summary>
    public interface INamedEntity : IBaseEntity
    {
        /// <summary>
        /// Name
        /// </summary>
        string Name { get; set; }
    }
}
