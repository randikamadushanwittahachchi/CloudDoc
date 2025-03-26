using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CloudDoc.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; internal set; } = null!;
    public string? Address { get; internal set; }
    public virtual List<Document> Documents { get; set; }= default!;
}
