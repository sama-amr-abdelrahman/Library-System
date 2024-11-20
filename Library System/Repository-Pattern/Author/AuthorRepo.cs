using Library_System.AppContext;
using Library_System.DTOs;
using Library_System.DTOs.Author;
using Library_System.DTOs.Book;
using Library_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Repository_Pattern.Author
{
    public class AuthorRepo : IAuthorRepo
    {
        private readonly AppDbContext _context;
        public AuthorRepo(AppDbContext context)
        {
            _context = context;
        }
        public bool AddAuthorWithBook(AuthorDTO authorDTO)
        {
            /*AuthorModel authorModel = new AuthorModel()
            {
                AuthorModelName = authorDTO.AuthorModelName,
                AuthorModelEmail = authorDTO.AuthorModelEmail,
                AuthorModelPhone = authorDTO.AuthorModelPhone,
                Books = new List<BookModel>()
            };
            BookModel bookModel = new BookModel()
            {
                BookModelTitle = authorDTO.Book.BookModelTitle,
                BookModelPuplishedYear = authorDTO.Book.BookModelPuplishedYear,
            };
            authorModel.Books.Add(bookModel);
            _context.Author.Add(authorModel);
            _context.SaveChanges();
            return true;*/
            AuthorModel authorModel = new AuthorModel()
            {
                AuthorModelName = authorDTO.AuthorModelName,
                AuthorModelEmail = authorDTO.AuthorModelEmail,
                AuthorModelPhone = authorDTO.AuthorModelPhone,
                Books = authorDTO.Book.Select(i => new BookModel
                {
                    BookModelTitle = i.BookModelTitle,
                    BookModelPuplishedYear = i.BookModelPuplishedYear,
                }).ToList(),
            };
            _context.Author.Add(authorModel);
            _context.SaveChanges();
            return true;
        }
        public AuthorDTO GetByID(int Id)
        {
            var auth = _context.Author
                .Include(x => x.Books)
                .Include(x => x.CreditCards)
                .Include(x => x.IndentityCard)
                .Where(x => x.AuthorModelId == Id)
                .Select(s => new AuthorDTO
                {
                    AuthorModelEmail = s.AuthorModelEmail,
                    AuthorModelPhone = s.AuthorModelPhone,
                    AuthorModelName = s.AuthorModelName,
                    Book = s.Books.Select(i => new BookDTO
                    {
                        BookModelTitle = i.BookModelTitle,
                        BookModelPuplishedYear = i.BookModelPuplishedYear
                    }).ToList(),
                    IdentityCard = new DTOs.IdentityCardDTO
                    {
                        ExpiaryDate = s.IndentityCard.ExpiaryDate
                    },
                    CrediteCard = s.CreditCards.Select(x => new CrediteCardDTO
                    {
                        CreditCardName = x.CreditCardName,
                        CreditCardType = x.CreditCardType,
                    }).ToList(),
                }).FirstOrDefault();
            return auth;
        }
    }
}
