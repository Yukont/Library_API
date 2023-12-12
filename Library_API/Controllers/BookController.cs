using Library_API.BLL.DTO;
using Library_API.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService bookService;
        public BookController(IBookService bookService) 
        {
            this.bookService = bookService;
        }
        [HttpGet("GetBooks")]
        public async Task<ActionResult> GetBooks()
        {
            var books = await bookService.GetAllBook();
            return Ok(books);
        }
        [HttpGet("GetBookById{id}")]
        public async Task<ActionResult> GetBook(int id)
        {
            var book = await bookService.GetBookById(id);
            return Ok(book);
        }
        [HttpGet("GetBookByISBN{ISBN}")]
        public async Task<ActionResult> GetBookByISBN(string ISBN)
        {
            var book = await bookService.GetBookByISBN(ISBN);
            return Ok(book);
        }
        [HttpPost("CreateBook")]
        public async Task<ActionResult> CreateBook(BookDTO bookDTO)
        {
            await bookService.AddBook(bookDTO);
            return Ok();
        }
        [HttpPut("UpdateBook")]
        public async Task<ActionResult> UpdateBook(BookDTO bookDTO)
        {
            await bookService.UpdateBook(bookDTO);
            return NoContent();
        }
        [HttpDelete("DeleteBook{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await bookService.RemoveBook(id);
            return NoContent();
        }
    }
}
