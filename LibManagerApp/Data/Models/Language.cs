using System.Collections.Generic;

namespace LibManagerApp.Data.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Book_Language> Book_Languages { get; set; }
    }
}
