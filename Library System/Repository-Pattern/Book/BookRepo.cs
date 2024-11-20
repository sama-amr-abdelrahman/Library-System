using Library_System.AppContext;
using Library_System.DTOs;
using Library_System.DTOs.Author;
using Library_System.DTOs.Book;
using Library_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_System.Repository_Pattern.Book
{
    public class BookRepo : IBookRepo
    {
        private readonly AppDbContext _context;
        public BookRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool AddBook(BookDTO book)
        {
            var title = _context.Book.FirstOrDefault(x => x.BookModelTitle == book.BookModelTitle);
            if (title != null) 
                return false;
            BookModel bookm = new BookModel()
            {
                BookModelTitle = book.BookModelTitle,
                BookModelPuplishedYear = book.BookModelPuplishedYear,
                authors = new List<AuthorModel>(),
                genres = new List<GenreModel>(),
            };
            _context.Book.Add(bookm);
            _context.SaveChanges();
            return true;
        }

        public bool AddGenreAuthor(BookAuthorGenreDTo bookAuthorGenre)
        {
            var allTitles = _context.Book.Select(x => x.BookModelTitle).ToList();
            var titleComed = bookAuthorGenre.genres.Select(x => x.GenreModelTitle).ToList();
            var dublicated = titleComed.Select(x => allTitles.Contains(x)).ToList();
            if(!dublicated.Any())
                return false;
            BookModel book = new BookModel()
            {
                BookModelTitle = bookAuthorGenre.BookModelTitle,
                BookModelPuplishedYear = bookAuthorGenre.BookModelPuplishedYear,
                authors = bookAuthorGenre.authors.Select(x => new AuthorModel
                {
                    AuthorModelName = x.AuthorModelNameDTO,
                    AuthorModelEmail = x.AuthorModelEmailDTO,
                    AuthorModelPhone = x.AuthorModelPhoneDTO,
                    CreditCards = x.crediteCard.Select(x => new CreditCard
                    {
                        CreditCardName = x.CreditCardName,
                        CreditCardType = x.CreditCardType,
                    }).ToList(),
                    IndentityCard = new IdentityCard
                    {
                        ExpiaryDate = x.identityCard.ExpiaryDate,
                    }
                }).ToList(),
                genres = bookAuthorGenre.genres.Select(x => new GenreModel
                {
                    GenreModelTitle = x.GenreModelTitle,
                }).ToList(),
            };
            _context.Book.Add(book);
            _context.SaveChanges();
            return true;
        }

        public BookDTOGet GetBookById(int id)
        {
            var book = _context.Book
                .Include(x => x.authors)
                .ThenInclude(x => x.CreditCards)
                .Include(x => x.genres)
                .Where(x => x.BookModelId == id)
                .Select(x => new BookDTOGet
                {
                    BookModelTitle = x.BookModelTitle,
                    BookModelPuplishedYear = x.BookModelPuplishedYear,
                    authorList = x.authors.Select(a => new AuthorBookAddDTO
                    {
                        AuthorModelNameDTO = a.AuthorModelName,
                        AuthorModelEmailDTO = a.AuthorModelEmail,
                        AuthorModelPhoneDTO = a.AuthorModelPhone,
                        crediteCard = a.CreditCards.Select(q => new CrediteCardDTO
                        {
                            CreditCardName = q.CreditCardName,
                            CreditCardType = q.CreditCardType,
                        }).ToList(),
                        identityCard = new IdentityCardDTO
                        {
                            ExpiaryDate = a.IndentityCard.ExpiaryDate,
                        }
                    }).ToList(),
                    GenreList = x.genres.Select(a => new GenreDTO
                    {
                        GenreModelTitle = a.GenreModelTitle,
                    }).ToList(),
                }).FirstOrDefault();
            return book;
        }

        /*public bool AddGenreAuthor(BookAuthorGenreDTo bookAuthorGenre)
        {
            var existgenre = _context.Book.Select(x => x.BookModelTitle).ToList();
            var uniqueGenre = bookAuthorGenre.genres.Select(x => x.GenreModelTitle).ToList();
            var genreres = uniqueGenre.Where(s => existgenre.Contains(s)).ToList();
            if(genreres.Any()) 
                return false;
            BookModel book = new BookModel()
            {
                BookModelTitle = bookAuthorGenre.BookModelTitle,
                BookModelPuplishedYear = bookAuthorGenre.BookModelPuplishedYear,
                authors = bookAuthorGenre.authors.Select(x => new AuthorModel()
                {
                    AuthorModelEmail = x.AuthorModelEmailDTO,
                    AuthorModelName = x.AuthorModelPhoneDTO,
                    AuthorModelPhone = x.AuthorModelPhoneDTO,
                }).ToList(),
                genres = bookAuthorGenre.genres.Select(x => new GenreModel()
                {
                    GenreModelTitle = x.GenreModelTitle,
                }).ToList(),
            };
            _context.Book.Add(book);
            _context.SaveChanges();
            return true;
        }*/

        /*public BookDTOGet GetBookById(int id)
        {
            var book = _context.Book
                .Where(x => x.BookModelId == id)
                .Include(x => x.authors)
                .Include (x => x.genres)
                .Select (x => new BookDTOGet
                {
                    BookModelTitle = x.BookModelTitle,
                    BookModelPuplishedYear = x.BookModelPuplishedYear,
                    authorList = x.authors.Select(x => new AuthorBookAddDTO
                    {
                        AuthorModelNameDTO = x.AuthorModelName,
                        AuthorModelEmailDTO = x.AuthorModelEmail,
                        AuthorModelPhoneDTO = x.AuthorModelPhone,
                    }).ToList(),
                    GenreList = x.genres.Select(s => new GenreDTO
                    {
                        GenreModelTitle = s.GenreModelTitle,
                    }).ToList()
                })
                .FirstOrDefault();
            return book;
        }*/

        public List<BookDTOGet> GetBooks()
        {
            var bookFound = _context.Book
                .Include(x => x.authors)
                .ThenInclude(x => x.IndentityCard)
                .Include(x=>x.authors)
                .ThenInclude(x => x.CreditCards)
                .Include(x => x.genres)
                .Select(x => new BookDTOGet
                {
                    BookModelTitle = x.BookModelTitle,
                    BookModelPuplishedYear = x.BookModelPuplishedYear,
                    authorList = x.authors.Select(s => new AuthorBookAddDTO
                    {
                        AuthorModelNameDTO = s.AuthorModelName,
                        AuthorModelEmailDTO = s.AuthorModelEmail,
                        AuthorModelPhoneDTO = s.AuthorModelPhone,
                        crediteCard = s.CreditCards.Select(a => new CrediteCardDTO
                        {
                            CreditCardName = a.CreditCardName,
                            CreditCardType = a.CreditCardType,
                        }).ToList(),
                        identityCard = new IdentityCardDTO
                        {
                            ExpiaryDate = s.IndentityCard.ExpiaryDate,
                        }
                    }).ToList(),
                    GenreList =x.genres.Select(s => new GenreDTO
                    {
                        GenreModelTitle = s.GenreModelTitle,
                    }).ToList()
                }).ToList();
            return bookFound;
        }

        public bool UpdateBook(int Id, BookAuthorGenreDTo book)
        {
            var bookFound = _context.Book
                .Include(x => x.authors)
                .ThenInclude(x => x.CreditCards)
                .Include(x => x.authors)
                .ThenInclude(x => x.IndentityCard)
                .Include(X => X.genres)
                .FirstOrDefault(x => x.BookModelId == Id);
            if (bookFound == null)
                return false;
            bookFound.BookModelPuplishedYear = book.BookModelPuplishedYear;
            bookFound.BookModelTitle = book.BookModelTitle;
            bookFound.authors = book.authors.Select(x => new AuthorModel
            {
                AuthorModelName = x.AuthorModelNameDTO,
                AuthorModelEmail = x.AuthorModelEmailDTO,
                AuthorModelPhone = x.AuthorModelPhoneDTO,
                CreditCards = x.crediteCard.Select(a => new CreditCard
                {
                    CreditCardName = a.CreditCardName,
                    CreditCardType = a.CreditCardType,
                }).ToList(),
                IndentityCard = new IdentityCard
                {
                    ExpiaryDate = x.identityCard.ExpiaryDate,
                },
            }).ToList();
            bookFound.genres = book.genres.Select(x => new GenreModel
            {
                GenreModelTitle = x.GenreModelTitle,
            }).ToList();
            _context.Book.Update(bookFound);
            _context.SaveChanges();
            return true;
        }

        /*public List<BookDTOGet> GetBooks()
        {
            var allBooks = _context.Book
                .Include(x => x.authors)
                .Include(x => x.genres)
                .Select(x => new BookDTOGet()
                {
                    BookModelTitle = x.BookModelTitle,
                    BookModelPuplishedYear = x.BookModelPuplishedYear,
                    GenreList = x.genres.Select(s => new GenreDTO
                    {
                        GenreModelTitle = s.GenreModelTitle
                    }).ToList(),
                    authorList = x.authors.Select(x => new AuthorBookAddDTO
                    {
                        AuthorModelEmailDTO = x.AuthorModelEmail,
                        AuthorModelNameDTO = x.AuthorModelName,
                        AuthorModelPhoneDTO = x.AuthorModelPhone
                    }).ToList(),
                }).ToList();
            return allBooks;
        }*/
    }
}
