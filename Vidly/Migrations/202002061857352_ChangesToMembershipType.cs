namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesToMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 4");
            Sql("UPDATE MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
        }
        
        public override void Down()
        {
        }
    }
}
