using System.Collections.Generic;

namespace LibManagerApp.Data.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Author> Authors { get; set; }
    }
}
