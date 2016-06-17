namespace AsthmaMDWebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gotridoflists : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AlertEntity", "ChildId", "dbo.ChildEntity");
            DropForeignKey("dbo.LogEntity", "ChildId", "dbo.ChildEntity");
            DropIndex("dbo.AlertEntity", new[] { "ChildId" });
            DropIndex("dbo.LogEntity", new[] { "ChildId" });
            DropTable("dbo.AlertEntity");
            DropTable("dbo.LogEntity");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.LogId);
            
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
                .PrimaryKey(t => t.AlertId);
            
            CreateIndex("dbo.LogEntity", "ChildId");
            CreateIndex("dbo.AlertEntity", "ChildId");
            AddForeignKey("dbo.LogEntity", "ChildId", "dbo.ChildEntity", "ChildId", cascadeDelete: true);
            AddForeignKey("dbo.AlertEntity", "ChildId", "dbo.ChildEntity", "ChildId", cascadeDelete: true);
        }
    }
}
