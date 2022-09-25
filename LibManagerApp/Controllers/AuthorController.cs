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
    public class AuthorController : ControllerBase
    {
        public IAuthorService _authorService { get; set; }
        private readonly ILogger<IAuthorService> _logger;

        public AuthorController(IAuthorService authorService, ILogger<IAuthorService> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        [HttpPost("add-auther")]
        public IActionResult AddAuther([FromBody] AuthorVM autherVM)
        {
            try
            {
                _logger.LogInformation("AddAuthor Info");
                var author = _authorService.AddAuthor(autherVM);
                return Ok(author);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddAuthor {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-author")]
        public IActionResult UpdateAuthor(int id, AuthorVM authorVM)
        {
            try
            {
                _logger.LogInformation("UpdateAuthor Info");
                var author = _authorService.UpdateAuthor(id, authorVM);
                return Ok(author);
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateAuthor {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-author")]
        public IActionResult DeleteAuthor(int id)
        {
            try
            {
                _logger.LogInformation("DeleteAuthor Info");
                _authorService.RemoveAuthor(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteAuthor {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-auther-by-id")]
        public IActionResult GetAuther(int id)
        {
            try
            {
                _logger.LogInformation("GetAuthor");
                var auther = _authorService.GetAuthorById(id);
                return Ok(auther);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAuthor {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-authers")]
        public IActionResult GetAllAuther()
        {
            try
            {
                _logger.LogInformation("GetAllAuthors");
                var authers = _authorService.GetAllAuthors();
                return Ok(authers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllAuthors {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
