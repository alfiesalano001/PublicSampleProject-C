using System.ComponentModel.DataAnnotations;

namespace Repositories.BindingModels
{
    public class LoginBindingModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
       
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public bool RememberMe { get; set; }
    }
}
