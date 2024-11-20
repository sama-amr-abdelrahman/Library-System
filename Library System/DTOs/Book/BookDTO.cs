using System.ComponentModel.DataAnnotations;

namespace Library_System.DTOs.Book
{
    public class BookDTO
    {
        [Required]
        public string BookModelTitle { get; set; }
        public DateTime BookModelPuplishedYear { get; set; }
    }
}
