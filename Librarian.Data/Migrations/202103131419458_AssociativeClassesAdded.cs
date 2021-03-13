namespace Librarian.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssociativeClassesAdded : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.BookAuthors");
            DropPrimaryKey("dbo.GenreBooks");
            AddColumn("dbo.BookAuthors", "Id", cb => cb.Int(nullable: false, identity: true));
            AddColumn("dbo.GenreBooks", "Id", cb => cb.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.BookAuthors", "Id");
            AddPrimaryKey("dbo.GenreBooks", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.BookAuthors");
            DropPrimaryKey("dbo.GenreBooks");
            AddPrimaryKey("dbo.BookAuthors", new[] { "GenreId", "BookId" });
            AddPrimaryKey("dbo.GenreBooks", new[] { "AuthorId", "BookId" });
        }
    }
}
