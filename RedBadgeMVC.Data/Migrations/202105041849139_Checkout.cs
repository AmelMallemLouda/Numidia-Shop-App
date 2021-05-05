namespace RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Checkout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false, maxLength: 40),
                        State = c.String(nullable: false),
                        ZipCode = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderDetail",
                c => new
                    {
                        OrderDetailId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OrderQuantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderDetailId)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetail", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderDetail", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderDetail", new[] { "ProductId" });
            DropIndex("dbo.OrderDetail", new[] { "OrderId" });
            DropTable("dbo.OrderDetail");
            DropTable("dbo.Order");
        }
    }
}
