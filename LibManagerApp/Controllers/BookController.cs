using LibManagerApp.Data.ViewModels;
using LibManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookService _bookService { get; set; }

        public BookController(BookService bookService)
        {
            _bookService= bookService;
        }
        [HttpGet("get-all-books")]   
        public IActionResult GetAllBook()
        {
            var books= _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPost("add-book_with-author")]
        public IActionResult AddBook([FromBody]BookVM book)
        {
            _bookService.AddBookWithAuthor(book);
            return Ok();
        }
    }
}
