using Library_System.DTOs.Author;
using Library_System.Repository_Pattern.Author;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorRepo _authorRepo;
        public AuthorController(IAuthorRepo authorRepo)
        {
            _authorRepo = authorRepo;
        }
        [HttpPost("AddAuthorWithBook")]
        public IActionResult AddAuthorWithBook(AuthorDTO authorDTO)
        {
            var res = _authorRepo.AddAuthorWithBook(authorDTO);
            if(!res)
                return BadRequest();
            return Ok();
        }
        [HttpGet("GetAuthorById")]
        public IActionResult GetAuthorById(int Id)
        {
            var res = _authorRepo.GetByID(Id);
            if(res == null) 
                return NotFound();
            return Ok(res);
        }
    }
}
