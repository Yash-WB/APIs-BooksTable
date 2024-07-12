using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoProject.Model
{
    [Table("Books")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "AuthorId is required")]
        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "PublisherId is required")]
        [ForeignKey("Publisher")]
        public int PublisherId { get; set; }

        // Navigation properties
        public virtual Author Author { get; set; }
        public virtual Publisher Publisher { get; set; }
    }
}
