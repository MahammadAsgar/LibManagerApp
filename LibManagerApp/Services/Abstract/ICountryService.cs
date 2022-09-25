using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using System.Collections.Generic;

namespace LibManagerApp.Services.Abstract
{
    public interface ICountryService
    {
        public Country AddCountry(CountryVM countryVM);
        public Country UpdateCountry(int id, CountryVM countryVM);
        public void RemoveCountry(int id);
        public Country GetCountryById(int id);
        public IEnumerable<Country> GetAllCountries();
    }
}
