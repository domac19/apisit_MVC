namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNewColumnIsAvaliable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "IsAvaliable", c => c.Int(nullable: false));
            Sql("UPDATE dbo.Movies SET IsAvaliable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "IsAvaliable");
        }
    }
}
