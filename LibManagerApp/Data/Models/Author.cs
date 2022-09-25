using System.Collections.Generic;

namespace LibManagerApp.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        //navigation
        public List<Book_Author> Book_Authors { get; set; }

    }
}
