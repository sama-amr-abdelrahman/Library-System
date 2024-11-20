using Library_System.DTOs.Book;

namespace Library_System.DTOs.Author
{
    public class AuthorDTO
    {
        public string AuthorModelName { get; set; }
        public string AuthorModelEmail { get; set; }
        public string AuthorModelPhone { get; set; }
        public List<BookDTO> Book { get; set; }
        public IdentityCardDTO IdentityCard { get; set; }
        public List<CrediteCardDTO> CrediteCard { get; set; }
    }
}
