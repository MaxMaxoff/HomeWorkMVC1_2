namespace HomeWorkMVC1.Domain.Models.Base
{
    public class NamedEntity : INamedEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
