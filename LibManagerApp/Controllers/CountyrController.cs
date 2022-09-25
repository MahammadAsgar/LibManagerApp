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
    public class CountryController : ControllerBase
    {
        public ICountryService _countryService { get; set; }
        private readonly ILogger<ICountryService> _logger;

        public CountryController(ICountryService countryService, ILogger<ICountryService> logger)
        {
            _countryService = countryService;
            _logger = logger;
        }

        [HttpPost("add-country")]
        public IActionResult AddCountry([FromBody] CountryVM counrtyVM)
        {
            try
            {
                _logger.LogInformation("AddCountry Info");
                var country = _countryService.AddCountry(counrtyVM);
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError($"AddCountry {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-country")]
        public IActionResult UpdateCountry(int id, CountryVM countryVM)
        {
            try
            {
                _logger.LogInformation("UpdateCountry Info");
                var country = _countryService.UpdateCountry(id, countryVM);
                return Ok(country);

            }
            catch (Exception ex)
            {
                _logger.LogError($"UpdateCountry {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-country")]
        public IActionResult DeleteCountry(int id)
        {
            try
            {
                _logger.LogInformation("DeleteCountry Info");
                _countryService.RemoveCountry(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"DeleteCountry {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-country-by-id")]
        public IActionResult GetCountryById(int id)
        {
            try
            {
                _logger.LogInformation("GetCountry Info");
                var country = _countryService.GetCountryById(id);
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetCounytry {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-all-countries")]
        public IActionResult GetAllCountry()
        {
            try
            {
                _logger.LogInformation("GetAllCOuntries Info");
                var countries = _countryService.GetAllCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllCountries {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}
