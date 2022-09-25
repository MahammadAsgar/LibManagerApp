using LibManagerApp.Data.ViewModels;
using LibManagerApp.Services;
using LibManagerApp.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace LibManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookService _bookService { get; set; }
        private readonly ILogger<IBookService> _logger;

        public BookController(IBookService bookService, ILogger<IBookService> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            try
            {
                _logger.LogInformation("AddBook Info");
                _bookService.AddBook(book);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddBook {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut("update-book")]
        //public IActionResult UpdateBook(int id, BookVM bookVM)
        //{
        //    var book=_bookService.UpdateBook(id, bookVM);
        //    return Ok(book);
        //}

        [HttpDelete("delete-book")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                _logger.LogInformation("DeleteBook Info");
                _bookService.RemoveBook(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteBook {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-book-by-id")]
        public IActionResult GetBook(int id)
        {
            try
            {
                _logger.LogInformation("GetBook Info");
                var book = _bookService.GetBookById(id);
                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetBook {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            try
            {
                _logger.LogInformation("GetAllBooks Info");
                var books = _bookService.GetAllBooks();
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllBooks {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
