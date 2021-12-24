using LibManagerApp.Data.ViewModels;
using LibManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        public LanguageService _languageService { get; set; }

        public LanguageController(LanguageService languageService)
        {
            _languageService = languageService;
        }

        [HttpGet("get-all-languages")]
        public IActionResult GetAllLanguage()
        {
            var languages = _languageService.GetLanguages();
            return Ok(languages);
        }
        [HttpPost("add-language")]
        public IActionResult AddLanguage([FromBody]LanguageVM language)
        {
            _languageService.AddLanguage(language); 
            return Ok();
        }
    }
}
