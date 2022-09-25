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
    public class GenreController : ControllerBase
    {
        public IGenreService _genreService { get; set; }
        private readonly ILogger<IGenreService> _logger;

        public GenreController(IGenreService genreService, ILogger<IGenreService> logger)
        {
            _genreService = genreService;
            _logger = logger;
        }
        [HttpPost("add-genre")]
        public IActionResult AddGenre([FromBody] GenreVM genreVM)
        {
            try
            {
                _logger.LogInformation("AddGenre Info");
                var genre = _genreService.AddGenre(genreVM);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddGenre {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-genre")]
        public IActionResult UpdateGenre(int id, [FromBody] GenreVM genreVM)
        {
            try
            {
                _logger.LogInformation("UpdateGenre Info");
                var genre = _genreService.UpdateGenre(id, genreVM);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateGenre {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-genre")]
        public IActionResult DeleteGenre(int id)
        {
            try
            {
                _logger.LogInformation("DeleteGenre Info");
                _genreService.RemoveGenre(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteGenre {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-genre-by-Id")]
        public IActionResult GetGenreById(int id)
        {
            try
            {
                _logger.LogInformation("GetGenre Info");
                var genre = _genreService.GetGenreById(id);
                return Ok(genre);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetGenre {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-genres")]
        public IActionResult GetAllGenre()
        {
            try
            {
                _logger.LogInformation("GetAllGenres Info");
                var genres = _genreService.GetAllGenres();
                return Ok(genres);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllGenres {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
