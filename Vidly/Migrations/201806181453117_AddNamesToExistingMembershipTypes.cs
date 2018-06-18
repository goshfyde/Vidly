using System.Data.Entity.Core.Metadata.Edm;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNamesToExistingMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes Set Name = 'Pay As You Go' Where id = 1");
            Sql("Update MembershipTypes Set Name = 'Monthly' Where id = 2");
            Sql("Update MembershipTypes Set Name = 'Quarterly' Where id = 3");
            Sql("Update MembershipTypes Set Name = 'Annual' Where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
