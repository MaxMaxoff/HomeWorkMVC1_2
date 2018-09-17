using HomeWorkMVC1.Domain.Models.Base;
using System.Collections.Generic;

namespace HomeWorkMVC1.Models.Product
{
    public class SectionViewModel : INamedEntity, IOrderedEntity
    {
        public SectionViewModel()
        {
            ChildSections = new List<SectionViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        /// <summary>
        /// Child Sections
        /// </summary>
        public List<SectionViewModel> ChildSections { get; set; }

        /// <summary>
        /// Parent Section
        /// </summary>
        public SectionViewModel ParentSection { get; set; }
    }
}
