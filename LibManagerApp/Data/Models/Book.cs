using System;
using System.Collections.Generic;

namespace LibManagerApp.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime DateAdded { get; set; }

        //navigation 
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        public List<Book_Author> Book_Authors { get; set; }
        public List<Book_Genre> Book_Genres { get; set; }
        public List<Book_Language> Book_Languages { get; set; }


    }
}
