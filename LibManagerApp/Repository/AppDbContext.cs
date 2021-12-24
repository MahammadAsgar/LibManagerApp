using LibManagerApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LibManagerApp.Repository
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.BookId);
         
            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.AuthorId);


            modelBuilder.Entity<Book_Genre>()
                .HasOne(b => b.Book)
                .WithMany(bg => bg.Book_Genres)
                .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Genre>()
               .HasOne(b => b.Genre)
               .WithMany(bg => bg.Book_Genres)
               .HasForeignKey(bi => bi.GenreId);

            modelBuilder.Entity<Author_Genre>()
                .HasOne(a => a.Author)
                .WithMany(ag => ag.Author_Genres)
                .HasForeignKey(ai => ai.AuthorId);

            modelBuilder.Entity<Author_Genre>()
               .HasOne(g => g.Genre)
               .WithMany(ag=>ag.Author_Genres)
               .HasForeignKey(gi => gi.GenreId);

            modelBuilder.Entity<Book_Language>()
               .HasOne(b => b.Book)
               .WithMany(bl => bl.Book_Languages)
               .HasForeignKey(bi => bi.BookId);

            modelBuilder.Entity<Book_Language>()
               .HasOne(l => l.Language)
               .WithMany(bl => bl.Book_Languages)
               .HasForeignKey(li => li.LanguageId);



        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Book_Genre> Book_Genres { get; set; }
        public DbSet<Author_Genre> Author_Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Book_Language> Book_Languages { get; set; }








    }
}
