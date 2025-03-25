using System.ComponentModel.DataAnnotations;

namespace CloudDoc.ViewModels;

public class UserRegisterViewModel
{
    [Required(ErrorMessage = "Full Name Is Required")]
    [Display(Name = "Full Name")]
    public string FullName { get; set; } = null!;

    [Required(ErrorMessage = "User EmailAddress Is Required")]
    [Display(Name = "User EmailAddress")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Password Is Required")]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Confirm Password Is Required")]
    [Display(Name = "Confirm Password")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password and Confirm Password Do Not Match")]
    public string ConfirmPassword { get; set; } = null!;

    [Display(Name = "User Address")]
    public string? Address { get; set; }



}
