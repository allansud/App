using System.ComponentModel.DataAnnotations;

namespace App.Identity.Model
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Nome da Role")]
        public string Name { get; set; }
    }
}
