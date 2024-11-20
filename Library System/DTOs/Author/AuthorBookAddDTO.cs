using Library_System.Models;

namespace Library_System.DTOs.Author
{
    public class AuthorBookAddDTO
    {
        public string AuthorModelNameDTO { get; set; }
        public string AuthorModelEmailDTO { get; set; }
        public string AuthorModelPhoneDTO { get; set; }
        public List<CrediteCardDTO> crediteCard { get; set; }
        public IdentityCardDTO identityCard { get; set; }
    }
}
