using Librarian.Domain.Models.Core;
using System.Data.Entity;

namespace Librarian.Data.Data
{
    public class LibrarianContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreBook> GenreBooks { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }

        public LibrarianContext() : base("Librarian")
        {
#if DEBUG
            Database.SetInitializer(new DataBaseInitializer());
#endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
