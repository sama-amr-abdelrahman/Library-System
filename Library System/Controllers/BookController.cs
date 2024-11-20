using Library_System.DTOs.Book;
using Library_System.Models;
using Library_System.Repository_Pattern.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepo _bookRepo;
        public BookController(IBookRepo bookRepo)
        {
            _bookRepo = bookRepo;
        }
        [HttpPost("AddBook")]
        public IActionResult AddBook(BookDTO book)
        {
            var res = _bookRepo.AddBook(book);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpPost("AddBookAuthorGenre")]
        public IActionResult AddBookAuthorGenre(BookAuthorGenreDTo dto)
        {
            var res = _bookRepo.AddGenreAuthor(dto);
            if (!res)
                return BadRequest();
            return Ok();
        }
        [HttpGet("GetAllBooks")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookRepo.GetBooks();

            return Ok(allBooks);
        }
        [HttpGet("{Id}")]
        public IActionResult GetBook(int Id)
        {
            var book = _bookRepo.GetBookById(Id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }
        [HttpPut("UpdateBook")]
        public IActionResult UpdateBook(int Id, BookAuthorGenreDTo bookAuthor)
        {
            var res = _bookRepo.UpdateBook(Id, bookAuthor);
            if (!res)
                return NotFound();
            return Ok();
        }
    }
}
