using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using LibManagerApp.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class GenreService:IGenreService
    {
        private AppDbContext _context;
        public GenreService(AppDbContext context)
        {
            _context = context;
        }
        public Genre AddGenre(GenreVM genre)
        {
            var _genre = new Genre()
            {
                Name = genre.Name,
            };
            _context.Genres.Add(_genre);
            _context.SaveChanges();
            return _genre;
        }
        public Genre UpdateGenre(int id, GenreVM genreVM)
        {
            var genre=_context.Genres.FirstOrDefault(x=>x.Id==id);
            genre.Name = genreVM.Name;
            _context.Genres.Update(genre);
            _context.SaveChanges();
            return genre;
        }
        public Genre GetGenreById(int id)
        {
            return _context.Genres.FirstOrDefault(p => p.Id == id);
        }

        public void RemoveGenre(int id)
        {
            var genre=_context.Genres.FirstOrDefault(x=>x.Id == id);
            _context.Genres.Remove(genre);
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return _context.Genres;
        }
    }
}
