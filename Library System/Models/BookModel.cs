using Library_System.DTOs.Author;

namespace Library_System.Models
{
    public class BookModel
    {
        public int BookModelId { get; set; }
        public string BookModelTitle { get; set; }
        public DateTime BookModelPuplishedYear { get; set; }
        public List<AuthorModel> authors { get; set; }
        public List<GenreModel> genres { get; set; }
    }
}
