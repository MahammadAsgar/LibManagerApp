using LibManagerApp.Data.ViewModels;
using LibManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        public GenreService _genreService { get; set; }
        public GenreController(GenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpPost("add-genre")]
        public IActionResult AddGenre([FromBody] GenreVM genre)
        {
            _genreService.AddGenre(genre);
            return Ok();
        }
        [HttpGet("get-all-genres")]
        public IActionResult GetAllGenre()
        {
            var genres = _genreService.GetGenres();
            return Ok(genres);
        }
    }
}
