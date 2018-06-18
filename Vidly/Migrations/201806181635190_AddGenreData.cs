namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreData : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("Insert Into Genres (Id, Name) Values (1, 'Comedy')");
            Sql("Insert Into Genres (Id, Name) Values (2, 'Action')");
            Sql("Insert Into Genres (Id, Name) Values (3, 'Family')");
            Sql("Insert Into Genres (Id, Name) Values (4, 'Romance')");
            Sql("Insert Into Genres (Id, Name) Values (5, 'Horror')");
        }
        
        public override void Down()
        {
        }
    }
}
