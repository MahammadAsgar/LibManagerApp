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
    public class LanguageController : ControllerBase
    {
        public ILanguageService _languageService { get; set; }
        private readonly ILogger<ILanguageService> _logger;

        public LanguageController(ILanguageService languageService, ILogger<ILanguageService> logger)
        {
            _languageService = languageService;
            _logger = logger;
        }

        [HttpPost("add-language")]
        public IActionResult AddLanguage([FromBody] LanguageVM languageVM)
        {
            try
            {
                _logger.LogInformation("AddLanguage Info");
                var language = _languageService.AddLanguage(languageVM);
                return Ok(language);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddLanguage {ex.Message}");
                return BadRequest(ex.Message);
            }

        }
        [HttpPut("update-language")]
        public IActionResult UpdateLanguage(int id, [FromBody] LanguageVM languageVM)
        {
            try
            {
                _logger.LogInformation("UpdateLanguage Info");
                var language = _languageService.UpdateLanguage(id, languageVM);
                return Ok(language);
            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateLanguage {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-language")]
        public IActionResult DeleteLanguage(int id)
        {
            try
            {
                _logger.LogInformation("DeleteLanguage Info");
                _languageService.RemoveLanguage(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteLanguage {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-language-by-id")]
        public IActionResult GetLanguageById(int id)
        {
            try
            {
                _logger.LogInformation("GetLanguage Info");
                var language = _languageService.GetLanguageById(id);
                return Ok(language);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetLanguage {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-languages")]
        public IActionResult GetAllLanguage()
        {
            try
            {
                _logger.LogInformation("GetAllLanguage");
                var languages = _languageService.GetAllLanguages();
                return Ok(languages);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllLanguage {ex.Message}");
                return (BadRequest(ex.Message));
            }
        }
    }
}
