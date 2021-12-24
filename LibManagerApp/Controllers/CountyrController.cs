using LibManagerApp.Data.ViewModels;
using LibManagerApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibManagerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public CountryService _countryService { get; set; }
        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }
        [HttpPost("add-country")]
        public IActionResult AddCountry([FromBody] CountryVM counrty)
        {
            _countryService.AddCountry(counrty);
            return Ok();
        }
        [HttpGet("get-all-country")]
        public IActionResult GetAllCountry()
        {
            var countries = _countryService.GetCountries();
            return Ok(countries);
        }
    }
}
