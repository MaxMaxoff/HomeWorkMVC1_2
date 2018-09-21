namespace HomeWorkMVC1.Domain.Models.Base
{
    public class NamedEntity : BaseEntity, INamedEntity
    {
        public string Name { get; set; }
    }

}
