namespace Library_System.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }
        public string CreditCardName { get; set; }
        public string CreditCardType { get; set; }
        public int AuthorModelId { get; set; }
        public AuthorModel Author { get; set; }
    }
}
