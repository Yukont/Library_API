using Library_API.BLL.DTO;
using Library_API.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/books")]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService) 
        {
            this.bookService = bookService;
        }
        [HttpGet("books")]
        public async Task<ActionResult> GetBooks()
        {
            var books = await bookService.GetAllBook();
            return Ok(books);
        }
        [HttpGet("book/{id}")]
        public async Task<ActionResult> GetBook(int id)
        {
            var book = await bookService.GetBookById(id);
            return Ok(book);
        }
        [HttpGet("bookbyisbn/{ISBN}")]
        public async Task<ActionResult> GetBookByISBN(string ISBN)
        {
            var book = await bookService.GetBookByISBN(ISBN);
            return Ok(book);
        }
        [HttpPost("book")]
        public async Task<ActionResult> CreateBook(BookDTO bookDTO)
        {
            await bookService.AddBook(bookDTO);
            return Ok();
        }
        [HttpPut("book")]
        public async Task<ActionResult> UpdateBook(BookDTO bookDTO)
        {
            await bookService.UpdateBook(bookDTO);
            return NoContent();
        }
        [HttpDelete("book/{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await bookService.RemoveBook(id);
            return NoContent();
        }
    }
}
