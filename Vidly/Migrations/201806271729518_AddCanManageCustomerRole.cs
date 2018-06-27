namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCanManageCustomerRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'48382da9-7b12-ad42-ae8a-22e873943gb6', N'CanManageCustomers')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'893407fc-df74-4e72-9b8e-2b05aaa7419c', N'48382da9-7b12-ad42-ae8a-22e873943gb6')");
        }
        
        public override void Down()
        {
        }
    }
}
