using Library_System.DTOs.Book;
using Library_System.Models;

namespace Library_System.Repository_Pattern.Book
{
    public interface IBookRepo
    {
        public bool AddBook(BookDTO book);
        public bool AddGenreAuthor(BookAuthorGenreDTo bookAuthorGenre);
        public List<BookDTOGet> GetBooks();
        public BookDTOGet GetBookById(int id);
        public bool UpdateBook(int Id, BookAuthorGenreDTo book);
    }
}
