using Library_System.DTOs.Author;

namespace Library_System.Repository_Pattern.Author
{
    public interface IAuthorRepo
    {
        public bool AddAuthorWithBook(AuthorDTO authorDTO);
        public AuthorDTO GetByID(int Id);
    }
}
