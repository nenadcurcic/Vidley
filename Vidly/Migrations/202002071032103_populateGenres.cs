namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Drama')");
            Sql("INSERT INTO Genres (Name) VALUES ('Horor')");
            Sql("INSERT INTO Genres (Name) VALUES ('Porn')");
            Sql("INSERT INTO Genres (Name) VALUES ('History')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");            
        }
        
        public override void Down()
        {
        }
    }
}
