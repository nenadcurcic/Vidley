namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewPropertiesToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ShureName", c => c.String());
            AddColumn("dbo.Customers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
            DropColumn("dbo.Customers", "Age");
            DropColumn("dbo.Customers", "ShureName");
        }
    }
}
