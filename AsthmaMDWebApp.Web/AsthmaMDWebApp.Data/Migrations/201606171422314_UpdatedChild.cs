namespace AsthmaMDWebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedChild : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LogEntity", "CreatedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.LogEntity", "ModifiedUtc", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LogEntity", "ModifiedUtc");
            DropColumn("dbo.LogEntity", "CreatedUtc");
        }
    }
}
