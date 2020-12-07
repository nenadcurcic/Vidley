namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SyncDB : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Movies", name: "Genre_Id", newName: "GenresId");
            RenameIndex(table: "dbo.Movies", name: "IX_Genre_Id", newName: "IX_GenresId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Movies", name: "IX_GenresId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Movies", name: "GenresId", newName: "Genre_Id");
        }
    }
}
