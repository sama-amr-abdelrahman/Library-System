using Library_System.DTOs.Book;

namespace Library_System.Models
{
    public class GenreModel
    {
        public int GenreModelId { get; set; }
        public string GenreModelTitle { get; set; }
        public List<BookModel> books { get; set; }
    }
}
