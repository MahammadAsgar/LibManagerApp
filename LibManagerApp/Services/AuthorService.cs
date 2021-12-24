using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class AuthorService
    {
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthorWithGenre(AuthorVM authorVM)
        {
            var author = new Author()
            {
                FullName = authorVM.FullName,
                CountryId=authorVM.CountryId
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
            foreach (var id in authorVM.GenreIds)
            {
                var author_genre = new Author_Genre()
                {
                    AuthorId = author.Id,
                    GenreId = id
                };
                _context.Author_Genres.Add(author_genre);
                _context.SaveChanges();
            }
        }
        public List<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }
        public Author GetAuthorById(int id)
        {
            return _context.Authors.FirstOrDefault(a=> a.Id == id);
        }
    }
}
