using System.ComponentModel.DataAnnotations.Schema;

namespace Library_System.Models
{
    public class AuthorModel
    {
        public int AuthorModelId { get; set; }
        public string AuthorModelName { get; set; }
        public string AuthorModelEmail { get; set; }
        public string AuthorModelPhone { get; set; }
        public List<BookModel> Books { get; set; }
        public List<CreditCard> CreditCards { get; set; }
        public IdentityCard IndentityCard { get; set; }
        public int IdentityCardId { get; set; }
    }
}
