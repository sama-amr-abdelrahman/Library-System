namespace Library_System.Models
{
    public class IdentityCard
    {
        public int IdentityCardId { get; set; }
        public DateTime ExpiaryDate { get; set; }
        public AuthorModel Author { get; set; }
    }
}
