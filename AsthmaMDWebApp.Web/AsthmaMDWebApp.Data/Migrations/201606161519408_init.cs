namespace AsthmaMDWebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildEntity",
                c => new
                    {
                        ChildId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ChildName = c.String(),
                        ChildAge = c.Int(nullable: false),
                        ChildHeight = c.Single(nullable: false),
                        ChildPeakFlowMeter = c.Int(nullable: false),
                        ChildFEV1 = c.Single(nullable: false),
                        CreatedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUtc = c.DateTimeOffset(nullable: false, precision: 7),
                        Gender = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ChildId);
            
            CreateTable(
                "dbo.AlertEntity",
                c => new
                    {
                        AlertId = c.Int(nullable: false, identity: true),
                        ChildId = c.Int(nullable: false),
                        Mdeicine = c.String(),
                        AlertStartTime = c.DateTimeOffset(nullable: false, precision: 7),
                        AlertStartDate = c.DateTimeOffset(nullable: false, precision: 7),
                        AlertEndTime = c.DateTimeOffset(nullable: false, precision: 7),
                        AlertEndDate = c.DateTimeOffset(nullable: false, precision: 7),
                        AlertName = c.String(),
                    })
                .PrimaryKey(t => t.AlertId)
                .ForeignKey("dbo.ChildEntity", t => t.ChildId, cascadeDelete: true)
                .Index(t => t.ChildId);
            
            CreateTable(
                "dbo.LogEntity",
                c => new
                    {
                        LogId = c.Int(nullable: false, identity: true),
                        ChildId = c.Int(nullable: false),
                        LogDate = c.DateTimeOffset(nullable: false, precision: 7),
                        LogPeakFlowMeter = c.Int(nullable: false),
                        LogFAV1 = c.Single(nullable: false),
                        Symptoms = c.String(),
                        Triggers = c.String(),
                        Medication = c.String(),
                        SeverityLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LogId)
                .ForeignKey("dbo.ChildEntity", t => t.ChildId, cascadeDelete: true)
                .Index(t => t.ChildId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogEntity", "ChildId", "dbo.ChildEntity");
            DropForeignKey("dbo.AlertEntity", "ChildId", "dbo.ChildEntity");
            DropIndex("dbo.LogEntity", new[] { "ChildId" });
            DropIndex("dbo.AlertEntity", new[] { "ChildId" });
            DropTable("dbo.LogEntity");
            DropTable("dbo.AlertEntity");
            DropTable("dbo.ChildEntity");
        }
    }
}
