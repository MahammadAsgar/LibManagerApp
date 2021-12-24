using System.Collections.Generic;

namespace LibManagerApp.Data.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book_Genre> Book_Genres { get; set; }

        public List<Author_Genre> Author_Genres { get; set; }
    }
}
