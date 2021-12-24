using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class BookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthor(BookVM bookVM)
        {
            var book = new Book
            {
                Name = bookVM.Name,
                Description = bookVM.Description,
                PublishDate = bookVM.PublishDate,
                DateAdded=System.DateTime.Now.Date,
                Rate= bookVM.Rate,
                PublisherId=bookVM.PublisherId,
            };
            _context.Books.Add(book);
            _context.SaveChanges();
            foreach (var id in bookVM.AuthorIds)
            {
                var book_author = new Book_Author()
                {
                    BookId = book.Id,
                    AuthorId = id,
                };
                _context.Book_Authors.Add(book_author);
                _context.SaveChanges();
            }
            foreach (var id in bookVM.GenreIds)
            {
                var book_genre = new Book_Genre()
                {
                    BookId = book.Id,
                    GenreId = id,
                };
                _context.Book_Genres.Add(book_genre);
                _context.SaveChanges();
            }
            foreach (var id in bookVM.LanguageIds)
            {
                var book_language = new Book_Language()
                {
                    BookId = book.Id,
                    LanguageId = id,
                };
                _context.Book_Languages.Add(book_language);
                _context.SaveChanges();
            }
        }
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }
        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(n => n.Id == id);
        }
    }
}
