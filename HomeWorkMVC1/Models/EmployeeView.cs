using System.ComponentModel.DataAnnotations;

namespace HomeWorkMVC1.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(HomeWorkMVC1.Resources.Resource), ErrorMessageResourceName = "RequiredFiledErrorMessage")]
        [Display(ResourceType = typeof(HomeWorkMVC1.Resources.Resource), Name = "FirstName")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessageResourceType = typeof(HomeWorkMVC1.Resources.Resource), ErrorMessageResourceName = "StringLength")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(HomeWorkMVC1.Resources.Resource), Name = "Patronymic")]
        public string Patronymic { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(HomeWorkMVC1.Resources.Resource), ErrorMessageResourceName = "RequiredFiledErrorMessage")]
        [Display(ResourceType = typeof(HomeWorkMVC1.Resources.Resource), Name = "SurName")]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessageResourceType = typeof(HomeWorkMVC1.Resources.Resource), ErrorMessageResourceName = "StringLength")]
        public string SurName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(HomeWorkMVC1.Resources.Resource), ErrorMessageResourceName = "RequiredFiledErrorMessage")]
        [Display(ResourceType = typeof(HomeWorkMVC1.Resources.Resource), Name = "Age")]
        public int Age { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessageResourceType = typeof(HomeWorkMVC1.Resources.Resource), ErrorMessageResourceName = "RequiredFiledErrorMessage")]
        [Display(ResourceType = typeof(HomeWorkMVC1.Resources.Resource), Name = "Position")]
        public string Position { get; set; }

    }
}
