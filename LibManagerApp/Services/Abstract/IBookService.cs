using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using System.Collections.Generic;

namespace LibManagerApp.Services.Abstract
{
    public interface IBookService
    {
        public Book AddBook(BookVM bookVM);
        //public Book UpdateBook(int id, BookVM bookVM);
        public void RemoveBook(int id);
        public Book GetBookById(int id);
        public IEnumerable<Book> GetAllBooks();
    }
}
