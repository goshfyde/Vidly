namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdayToBirthDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            DropColumn("dbo.Customers", "Birthday");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Birthday", c => c.DateTime());
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
