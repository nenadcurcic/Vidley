namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someShitUpdate : DbMigration
    {
        public override void Up()
        {
         
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Movies", new[] { "Genre_Id" });
            AlterColumn("dbo.Movies", "GenresId", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "Genre_Id");
            CreateIndex("dbo.Movies", "GenresId");
            AddForeignKey("dbo.Movies", "GenresId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
