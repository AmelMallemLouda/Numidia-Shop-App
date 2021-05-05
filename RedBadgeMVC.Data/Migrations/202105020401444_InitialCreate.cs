namespace RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cart",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        ProductId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                        DateCreated = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 50),
                        ProductDescription = c.String(nullable: false),
                        ProductPrice = c.Double(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        ItemCondition = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProductImage = c.String(),
                        CategoryName = c.String(),
                        StoreName = c.String(),
                        CategoryId = c.Int(nullable: false),
                        StoreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.StoreId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.StoreId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        CategoryName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Reviews = c.String(nullable: false),
                        OwnerID = c.Guid(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Store_StoreId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Store", t => t.Store_StoreId)
                .Index(t => t.ProductId)
                .Index(t => t.Store_StoreId);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        StoreId = c.Int(nullable: false, identity: true),
                        StoreName = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Address = c.String(),
                        OpeningTime = c.String(),
                        ClosingTime = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.StoreId);
            
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
            DropForeignKey("dbo.Cart", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "StoreId", "dbo.Store");
            DropForeignKey("dbo.Review", "Store_StoreId", "dbo.Store");
            DropForeignKey("dbo.Review", "ProductId", "dbo.Product");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Review", new[] { "Store_StoreId" });
            DropIndex("dbo.Review", new[] { "ProductId" });
            DropIndex("dbo.Product", new[] { "StoreId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Cart", new[] { "ProductId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Store");
            DropTable("dbo.Review");
            DropTable("dbo.Category");
            DropTable("dbo.Product");
            DropTable("dbo.Cart");
        }
    }
}
