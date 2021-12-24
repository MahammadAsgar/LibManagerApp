using System;
using System.Collections.Generic;

namespace LibManagerApp.Data.ViewModels
{
    public class BookVM
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? PublishDate { get; set; }
        public int Rate { get; set; }
        public int PublisherId { get; set; }

        public List<int> AuthorIds { get; set; }
        public List<int> GenreIds { get; set; }
        public List<int> LanguageIds { get; set; }

    }
}
