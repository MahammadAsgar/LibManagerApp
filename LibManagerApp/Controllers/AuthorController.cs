using LibManagerApp.Data.ViewModels;
using LibManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        public AuthorService _authorService { get; set; }

        public AuthorController(AuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpGet("get-all-authers")]
        public IActionResult GetAllAuther()
        {
            var auther = _authorService.GetAuthors();
            return Ok(auther);
        }

        [HttpPost("add-auther_with-genre_country")]
        public IActionResult AddAuther([FromBody] AuthorVM auther)
        {
            _authorService.AddAuthorWithGenre(auther);
            return Ok();
        }
    }
}
