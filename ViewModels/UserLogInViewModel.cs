using System.ComponentModel.DataAnnotations;

namespace CloudDoc.ViewModels
{
    public class UserLogInViewModel
    {
        [Required(ErrorMessage="User Name Is Required")]
        [Display(Name = "User Name")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; } = null!;


        [Required(ErrorMessage = "Password Is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
