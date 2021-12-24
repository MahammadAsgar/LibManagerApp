namespace LibManagerApp.Data.Models
{
    public class Book_Language
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
