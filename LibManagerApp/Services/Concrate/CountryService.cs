using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using LibManagerApp.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class CountryService:ICountryService
    {
        private AppDbContext _context;
        public CountryService(AppDbContext context)
        {
            _context = context;
        }
        public Country AddCountry(CountryVM countryVM)
        {
            var country = new Country()
            {
                Name = countryVM.CountryName
            };
            _context.Countries.Add(country); ;
            _context.SaveChanges();
            return country;
        }
        public Country UpdateCountry(int id, CountryVM countryVM)
        {
            var country=_context.Countries.FirstOrDefault(x=> x.Id == id);
            country.Name=countryVM.CountryName;
            _context.Countries.Update(country);
            _context.SaveChanges();
            return country;
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return _context.Countries;
        }

        public Country GetCountryById(int id)
        {
            return _context.Countries.FirstOrDefault(c=>c.Id== id);
        }

        public void RemoveCountry(int id)
        {
            var country=_context.Countries.FirstOrDefault(x=>x.Id==id);
            _context.Countries.Remove(country);
        }
    }
}
