namespace LibManagerApp.Data.Models
{
    public class Author_Genre
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
