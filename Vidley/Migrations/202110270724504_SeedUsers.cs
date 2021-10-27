namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'20f09473-bb1b-48ea-98aa-558f128097c5', N'admin@vidly.com', 0, N'AL8ZivFp7nZTIjkRsigV3kNn6fHUc2ajCAwmjFntBIDHfPO82zDpuacFPBIYzsBglw==', N'063033d1-d65b-4349-a705-5048a2ed5bc8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e08716d7-1778-4018-9d9a-c332b930cb93', N'licitar.domagoj@gmail.com', 0, N'AD0ORHxlvD3q4ZsyO2OzUbwQGYApo4BkVyQ7CHb0qrGWSL7v2UjjPXwHXRh66pGiTw==', N'5cda38ba-7d3d-4f7a-947b-027961930cbd', NULL, 0, 0, NULL, 1, 0, N'licitar.domagoj@gmail.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'75a34ec1-d516-4f93-82ea-e114ded43982', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'20f09473-bb1b-48ea-98aa-558f128097c5', N'75a34ec1-d516-4f93-82ea-e114ded43982')");
        }
        
        public override void Down()
        {
        }
    }
}
