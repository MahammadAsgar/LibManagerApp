using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using System.Collections.Generic;

namespace LibManagerApp.Services.Abstract
{
    public interface IGenreService
    {
        public Genre AddGenre(GenreVM genreVM);
        public Genre UpdateGenre(int id, GenreVM genreVM);
        public void RemoveGenre(int id);
        public Genre GetGenreById(int id);
        public IEnumerable<Genre> GetAllGenres();
    }
}
