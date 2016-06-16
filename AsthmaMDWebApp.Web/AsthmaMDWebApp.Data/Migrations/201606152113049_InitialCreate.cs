namespace AsthmaMDWebApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        Applicationuser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.Applicationuser", t => t.Applicationuser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.Applicationuser_Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        UserProfileId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        MiddleInitial = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Address1 = c.String(),
                        Address2 = c.String(),
                    })
                .PrimaryKey(t => t.UserProfileId);
            
            CreateTable(
                "dbo.Applicationuser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        Applicationuser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Applicationuser", t => t.Applicationuser_Id)
                .Index(t => t.Applicationuser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        Applicationuser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Applicationuser", t => t.Applicationuser_Id)
                .Index(t => t.Applicationuser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "Applicationuser_Id", "dbo.Applicationuser");
            DropForeignKey("dbo.IdentityUserLogin", "Applicationuser_Id", "dbo.Applicationuser");
            DropForeignKey("dbo.IdentityUserClaim", "Applicationuser_Id", "dbo.Applicationuser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropIndex("dbo.IdentityUserLogin", new[] { "Applicationuser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "Applicationuser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "Applicationuser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.Applicationuser");
            DropTable("dbo.UserProfile");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
        }
    }
}
