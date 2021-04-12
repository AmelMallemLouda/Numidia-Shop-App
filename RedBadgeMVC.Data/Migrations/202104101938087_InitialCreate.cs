namespace RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeautyHealth",
                c => new
                    {
                        BeautyhealthId = c.Int(nullable: false, identity: true),
                        BeautyHealthName = c.String(),
                    })
                .PrimaryKey(t => t.BeautyhealthId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        ClothingId = c.Int(nullable: false),
                        HomeId = c.Int(nullable: false),
                        BeautyHealthId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.BeautyHealth", t => t.BeautyHealthId, cascadeDelete: true)
                .ForeignKey("dbo.Clothing", t => t.ClothingId, cascadeDelete: true)
                .ForeignKey("dbo.HomeKitchen", t => t.HomeId, cascadeDelete: true)
                .Index(t => t.ClothingId)
                .Index(t => t.HomeId)
                .Index(t => t.BeautyHealthId);
            
            CreateTable(
                "dbo.Clothing",
                c => new
                    {
                        ClothingId = c.Int(nullable: false, identity: true),
                        ClothingName = c.String(),
                    })
                .PrimaryKey(t => t.ClothingId);
            
            CreateTable(
                "dbo.HomeKitchen",
                c => new
                    {
                        HomeKitchenId = c.Int(nullable: false, identity: true),
                        HomeKitchenName = c.String(),
                    })
                .PrimaryKey(t => t.HomeKitchenId);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        ItemName = c.String(nullable: false, maxLength: 50),
                        ItemDescription = c.String(nullable: false),
                        ItemPrice = c.Double(nullable: false),
                        ItemCondition = c.String(nullable: false),
                        HomeId = c.Int(nullable: false),
                        BautyId = c.Int(nullable: false),
                        ClothingId = c.Int(nullable: false),
                        BeautyHealth_BeautyhealthId = c.Int(),
                        HomeKitchen_HomeKitchenId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.BeautyHealth", t => t.BeautyHealth_BeautyhealthId)
                .ForeignKey("dbo.Clothing", t => t.ClothingId, cascadeDelete: true)
                .ForeignKey("dbo.HomeKitchen", t => t.HomeKitchen_HomeKitchenId)
                .Index(t => t.ClothingId)
                .Index(t => t.BeautyHealth_BeautyhealthId)
                .Index(t => t.HomeKitchen_HomeKitchenId);
            
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
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
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
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Item", "HomeKitchen_HomeKitchenId", "dbo.HomeKitchen");
            DropForeignKey("dbo.Item", "ClothingId", "dbo.Clothing");
            DropForeignKey("dbo.Item", "BeautyHealth_BeautyhealthId", "dbo.BeautyHealth");
            DropForeignKey("dbo.Category", "HomeId", "dbo.HomeKitchen");
            DropForeignKey("dbo.Category", "ClothingId", "dbo.Clothing");
            DropForeignKey("dbo.Category", "BeautyHealthId", "dbo.BeautyHealth");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Item", new[] { "HomeKitchen_HomeKitchenId" });
            DropIndex("dbo.Item", new[] { "BeautyHealth_BeautyhealthId" });
            DropIndex("dbo.Item", new[] { "ClothingId" });
            DropIndex("dbo.Category", new[] { "BeautyHealthId" });
            DropIndex("dbo.Category", new[] { "HomeId" });
            DropIndex("dbo.Category", new[] { "ClothingId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Item");
            DropTable("dbo.HomeKitchen");
            DropTable("dbo.Clothing");
            DropTable("dbo.Category");
            DropTable("dbo.BeautyHealth");
        }
    }
}
