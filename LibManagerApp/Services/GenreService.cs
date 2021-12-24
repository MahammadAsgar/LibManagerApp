using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class GenreService
    {
        private AppDbContext _context;
        public GenreService(AppDbContext context)
        {
            _context = context;
        }
        public void AddGenre(GenreVM genre)
        {
            var _genre = new Genre()
            {
                Name = genre.Name,
            };
            _context.Genres.Add(_genre);
            _context.SaveChanges();

        }
        public List<Genre> GetGenres()
        {
            return _context.Genres.ToList();
        }
        public Genre GetGenreById(int id)
        {
            return _context.Genres.FirstOrDefault(p => p.Id == id);
        }
    }
}
