using System.ComponentModel.DataAnnotations;

namespace ModernPortfolio.Models
{
    public class ProjectComment
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(50)]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Comment body cannot be empty.")]
        [StringLength(500)]
        public string Text { get; set; } = string.Empty;

        public DateTime PostedAt { get; set; } = DateTime.Now;
    }
}