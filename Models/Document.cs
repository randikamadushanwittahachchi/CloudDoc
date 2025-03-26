using System.ComponentModel.DataAnnotations;

namespace CloudDoc.Models
{
    public class Document
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string UserId { get; set; } = null!;
        public virtual AppUser User { get; set; } = null!;
    }
}
