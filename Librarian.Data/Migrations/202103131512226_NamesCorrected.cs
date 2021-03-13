namespace Librarian.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NamesCorrected : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.BookAuthors", name: "BookId", newName: "BookId");
            RenameColumn(table: "dbo.BookAuthors", name: "AuthorId", newName: "AuthorId");
            RenameColumn(table: "dbo.GenreBooks", name: "GenreId", newName: "GenreId");
            RenameColumn(table: "dbo.GenreBooks", name: "Book_Id", newName: "BookId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_BookId", newName: "IX_BookId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_AuthorId", newName: "IX_AuthorId");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_GenreId", newName: "IX_GenreId");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_BookId", newName: "IX_BookId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.GenreBooks", name: "IX_BookId", newName: "IX_BookId");
            RenameIndex(table: "dbo.GenreBooks", name: "IX_GenreId", newName: "IX_GenreId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_AuthorId", newName: "IX_AuthorId");
            RenameIndex(table: "dbo.BookAuthors", name: "IX_BookId", newName: "IX_BookId");
            RenameColumn(table: "dbo.GenreBooks", name: "BookId", newName: "Book_Id");
            RenameColumn(table: "dbo.GenreBooks", name: "GenreId", newName: "GenreId");
            RenameColumn(table: "dbo.BookAuthors", name: "AuthorId", newName: "AuthorId");
            RenameColumn(table: "dbo.BookAuthors", name: "BookId", newName: "BookId");
        }
    }
}
