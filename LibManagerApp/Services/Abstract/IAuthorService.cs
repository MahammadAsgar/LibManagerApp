using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using System.Collections.Generic;
namespace LibManagerApp.Services.Abstract
{
    public interface IAuthorService
    {
        public Author AddAuthor(AuthorVM authorVM);
        public void RemoveAuthor(int id);
        public Author UpdateAuthor(int id, AuthorVM authorVM);
        public Author GetAuthorById(int id);
        public IEnumerable<Author> GetAllAuthors();
    }
}
