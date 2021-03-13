namespace Librarian.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PKNamesCorrected : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookAuthors", name: "Book_Id", newName: "BookId");
            RenameColumn(table: "dbo.BookAuthors", name: "Author_Id", newName: "AuthorId");
            RenameColumn(table: "dbo.GenreBooks", name: "Genre_Id", newName: "GenreId");
            RenameColumn(table: "dbo.GenreBooks", name: "Book_Id", newName: "Book_Id");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Book_Id", newName: "IX_BookId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_Author_Id", newName: "IX_AuthorId");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_Genre_Id", newName: "IX_GenreId");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_Book_Id", newName: "IX_BookId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GenreBooks", name: "IX_BookId", newName: "IX_Book_Id");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_AuthorId", newName: "IX_Author_Id");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_BookId", newName: "IX_Book_Id");
            RenameColumn(table: "dbo.GenreBooks", name: "BookId", newName: "Book_Id");
            RenameColumn(table: "dbo.GenreBooks", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.BookAuthors", name: "AuthorId", newName: "Author_Id");
            RenameColumn(table: "dbo.BookAuthors", name: "BookId", newName: "Book_Id");
        }
    }
}
