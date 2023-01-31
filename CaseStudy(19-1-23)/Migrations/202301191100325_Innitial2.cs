namespace CaseStudy_19_1_23_.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Innitial2 : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        CUName = c.String(),
                        PId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CAId = c.Int(nullable: false, identity: true),
                        CAName = c.String(),
                    })
                .PrimaryKey(t => t.CAId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SuId = c.Int(nullable: false, identity: true),
                        SuName = c.String(),
                        CAId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SuId)
                .ForeignKey("dbo.Categories", t => t.CAId, cascadeDelete: true)
                .Index(t => t.CAId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        PId = c.Int(nullable: false, identity: true),
                        PName = c.String(),
                        PStocks = c.Int(nullable: false),
                        PPrice = c.Double(nullable: false),
                        PImage = c.String(),
                        SuId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PId)
                .ForeignKey("dbo.SubCategories", t => t.SuId, cascadeDelete: true)
                .Index(t => t.SuId);
            
            CreateTable(
                "dbo.Ordereds",
                c => new
                    {
                        OrId = c.Int(nullable: false, identity: true),
                        PId = c.Int(nullable: false),
                        OrUName = c.String(),
                        OrAdress = c.String(),
                        dateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OId = c.Int(nullable: false, identity: true),
                        PId = c.Int(nullable: false),
                        OUName = c.String(),
                        payment = c.String(),
                        OrAdress = c.String(),
                        dateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OId);
            
            CreateTable(
                "dbo.WishLists",
                c => new
                    {
                        WId = c.Int(nullable: false, identity: true),
                        PId = c.Int(nullable: false),
                        PUName = c.String(),
                    })
                .PrimaryKey(t => t.WId);
            
         
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId });
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Products", "SuId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CAId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "SuId" });
            DropIndex("dbo.SubCategories", new[] { "CAId" });
            DropTable("dbo.WishLists");
            DropTable("dbo.Orders");
            DropTable("dbo.Ordereds");
            DropTable("dbo.Products");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Carts");
            CreateIndex("dbo.AspNetUserLogins", "UserId");
            CreateIndex("dbo.AspNetUserClaims", "UserId");
            CreateIndex("dbo.AspNetUsers", "UserName", unique: true, name: "UserNameIndex");
            CreateIndex("dbo.AspNetUserRoles", "RoleId");
            CreateIndex("dbo.AspNetUserRoles", "UserId");
            CreateIndex("dbo.AspNetRoles", "Name", unique: true, name: "RoleNameIndex");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
        }
    }
}
