using Library_System.DTOs.Author;

namespace Library_System.Models
{
    public class BookAuthorGenreDTo
    {
        public string BookModelTitle { get; set; }
        public DateTime BookModelPuplishedYear { get; set; }
        public List<AuthorBookAddDTO> authors { get; set; }
        public List<GenreDTO> genres { get; set; }
    }
}
