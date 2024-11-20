using Library_System.DTOs.Author;
using Library_System.Models;

namespace Library_System.DTOs.Book
{
    public class BookDTOGet
    {
        public string BookModelTitle { get; set; }
        public DateTime BookModelPuplishedYear { get; set; }
        public List<GenreDTO> GenreList { get; set; }
        public List<AuthorBookAddDTO> authorList { get; set; }
    }
}
