using CloudDoc.Models;
using System.ComponentModel.DataAnnotations;

namespace CloudDoc.ViewModels
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Enter Titel")]
        public string? Title { get; set; }
        [Display(Name = "Enter Content")]
        public string? Content { get; set; }
        [Required]
        public string UserId { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;

    }
}
