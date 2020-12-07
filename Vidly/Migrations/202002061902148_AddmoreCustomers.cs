namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddmoreCustomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers VALUES ('Nenad', 'Nenadovic', 38, 3, 4, '12.6.1982')");
            Sql("INSERT INTO Customers VALUES ('John', 'Doe', 18, 0, 4, '5.5.2000')");
        }
        
        public override void Down()
        {
        }
    }
}
