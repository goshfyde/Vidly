namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4a97f8d6-f043-41f2-a21e-94be31f290c2', N'hayden.p.bush@gmail.com', 0, N'AKqECwfqaWZiq2bpufYpiRr5PAzDG81i7U6tR3nYhs7BPo4GMiI1+C8EzymGAxXrXg==', N'09d921aa-e26d-475a-bf55-a63f3f407f39', NULL, 0, 0, NULL, 1, 0, N'hayden.p.bush@gmail.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'893407fc-df74-4e72-9b8e-2b05aaa7419c', N'admin@vidly.com', 0, N'AEAEv91mNsAx8AWx/KL0O0hIiMFT9mDIeIUNP9YqY975ueWd3DQbn8JrtxZR3JmVfA==', N'4b52ab56-fc27-4f07-a7c3-82937f390e86', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a614b7a3-0517-4fd2-ab68-f0fb3b9b6e04', N'guest@vidly.com', 0, N'ADTUow6tkKDgN0IHUM355gjL3qPeOVAruncCVuHEVWDXmDu3VPvxw2xvvVWowCunrw==', N'67c29f03-4fe0-43ff-ae75-02dae20c5c61', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'48dc09c0-7b12-48bf-ae8a-22e873912e85', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'893407fc-df74-4e72-9b8e-2b05aaa7419c', N'48dc09c0-7b12-48bf-ae8a-22e873912e85')

");
        }
        
        public override void Down()
        {
        }
    }
}
