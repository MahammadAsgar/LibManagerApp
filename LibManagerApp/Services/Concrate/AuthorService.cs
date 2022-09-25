using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using LibManagerApp.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class AuthorService : IAuthorService
    {
        private AppDbContext _context;
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.FirstOrDefault(a => a.Id == id);
        }
    
        public Author AddAuthor(AuthorVM authorVM)
        {
            var author = new Author()
            {
                FullName = authorVM.FullName,
                CountryId = authorVM.CountryId
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }

        public Author UpdateAuthor(int id, AuthorVM authorVM)
        {
            var author=_context.Authors.FirstOrDefault(x=>x.Id==id);
            author.FullName = authorVM.FullName;
            author.CountryId = authorVM.CountryId;
            _context.Authors.Update(author);
            _context.SaveChanges();
            return author;
        }

        public void RemoveAuthor(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);
            _context.Authors.Remove(author);
        }

        public IEnumerable<Author> GetAllAuthors()
        {
            return _context.Authors;
        }
    }
}
