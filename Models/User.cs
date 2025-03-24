using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CloudDoc.Models;

public class User: IdentityUser
{
    [Required]
    public string FirstName { get; set; } = null!;
}
