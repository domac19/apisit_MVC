namespace Vidley.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGenreTypeToGenretypeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "GenreTypeId", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "GenreType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "GenreType", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "GenreTypeId");
        }
    }
}
