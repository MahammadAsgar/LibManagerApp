using LibManagerApp.Data.Models;
using LibManagerApp.Data.ViewModels;
using LibManagerApp.Repository;
using LibManagerApp.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace LibManagerApp.Services
{
    public class BookService : IBookService
    {
        private AppDbContext _context;
        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public Book AddBook(BookVM bookVM)
        {
            // int a = 0;
            var book = new Book()
            {
                Name = bookVM.Name,
                Description = bookVM.Description,
                Rate = bookVM.Rate,
                PublishDate = bookVM.PublishDate,
                DateAdded = System.DateTime.Now,

            };
            _context.Books.Add(book);
            _context.SaveChanges();
            foreach (var item in bookVM.AuthorIds)
            {
                var book_author = new Book_Author()
                {
                    BookId = book.Id,
                    AuthorId = item
                };
                _context.Book_Authors.Add(book_author);
                _context.SaveChanges();
            }
            foreach (var item in bookVM.GenreIds)
            {
                var book_genre = new Book_Genre()
                {
                    BookId = book.Id,
                    GenreId = item
                };
                _context.Book_Genres.Add(book_genre);
                _context.SaveChanges();
            }
            foreach (var item in bookVM.LanguageIds)
            {
                var book_language = new Book_Language()
                {
                    BookId = book.Id,
                    LanguageId = item
                };
                _context.Book_Languages.Add(book_language);
                _context.SaveChanges();
            }
            return book;
        }
        //public Book UpdateBook(int id, BookVM bookVM)
        //{
        //    var book = _context.Books.FirstOrDefault(x => x.Id == id);
        //    book.Name = bookVM.Name;
        //    book.Description = bookVM.Description;
        //    book.PublishDate = bookVM.PublishDate;
        //    book.DateAdded = System.DateTime.Now;
        //    book.Rate = bookVM.Rate;
        //    _context.Books.Update(book);
        //    _context.SaveChanges();
        //    foreach (var item in bookVM.AuthorIds)
        //    {
        //        var book_author = _context.Book_Authors.FirstOrDefault(a => a.Id == id);
        //        book_author.BookId = book.Id;
        //        book_author.AuthorId = item;
        //        _context.Book_Authors.Update(book_author);
        //        _context.SaveChanges();
        //    }
        //    foreach (var item in bookVM.GenreIds)
        //    {
        //        var book_genre = _context.Book_Genres.FirstOrDefault(a => a.Id == id);
        //        book_genre.BookId = book.Id;
        //        book_genre.GenreId = item;
        //        _context.Book_Genres.Update(book_genre);
        //        _context.SaveChanges();
        //    }
        //    foreach (var item in bookVM.LanguageIds)
        //    {
        //        var book_langauge = _context.Book_Languages.FirstOrDefault(a => a.Id == id);
        //        id++;
        //        book_langauge.LanguageId = item;
        //        book_langauge.BookId = book.Id;
        //        _context.Book_Languages.Update(book_langauge);
        //        _context.SaveChanges();
        //    }
        //    return book;
        //}

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(n => n.Id == id);
        }

        public void RemoveBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books;
        }
    }
}
