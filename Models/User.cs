using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CloudDoc.Models;

public class User : IdentityUser
{
    public string FullName { get; internal set; } = null!;
    public string? Address { get; internal set; }
}
