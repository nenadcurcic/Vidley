namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalPopulateCustomers : DbMigration
    {
        public override void Up()
        {
            //Sql("INSERT INTO Customers (Id, Name, ShureName, Age, IsSubscribed, MembershipType, Birthday) VALUES (3, John, Doe, 28, True, 3, '12.6.1982')");
            //Sql("INSERT INTO Customers (Id, Name, ShureName, Age, IsSubscribed, MembershipType, Birthday) VALUES (4, Jan, Polak, 60, False, 2, '5.12.1972')");
            Sql("UPDATE Customers SET Birthday = '8.8.1956' WHERE Id = 1");
        }
        
        public override void Down()
        {
        }
    }
}
