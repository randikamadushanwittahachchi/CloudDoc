using System.ComponentModel.DataAnnotations;

namespace CloudDoc.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage="User Email Is Required")]
        [Display(Name = "User Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = "Password Is Required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
