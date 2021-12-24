using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class CountryService
    {
        private AppDbContext _context;
        public CountryService(AppDbContext context)
        {
            _context = context;
        }
        public void AddCountry(CountryVM countryVM)
        {
            var country = new Country()
            {
                Name = countryVM.CountryName
            };
            _context.Countries.Add(country); ;
            _context.SaveChanges();
        }

        public List<Country> GetCountries()
        {
            return _context.Countries.ToList();
        }
        public Country GetCountryById(int id)
        {
            return _context.Countries.FirstOrDefault(c=>c.Id== id);
        }
    }
}
