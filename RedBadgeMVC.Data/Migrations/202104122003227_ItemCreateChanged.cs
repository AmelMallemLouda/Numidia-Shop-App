namespace RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemCreateChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "BeautyHealthId", "dbo.BeautyHealth");
            DropForeignKey("dbo.Item", "ClothingId", "dbo.Clothing");
            DropForeignKey("dbo.Item", "HomeKitchenId", "dbo.HomeKitchen");
            DropIndex("dbo.Item", new[] { "HomeKitchenId" });
            DropIndex("dbo.Item", new[] { "ClothingId" });
            DropIndex("dbo.Item", new[] { "BeautyHealthId" });
            AlterColumn("dbo.Item", "HomeKitchenId", c => c.Int());
            AlterColumn("dbo.Item", "ClothingId", c => c.Int());
            AlterColumn("dbo.Item", "BeautyHealthId", c => c.Int());
            CreateIndex("dbo.Item", "HomeKitchenId");
            CreateIndex("dbo.Item", "ClothingId");
            CreateIndex("dbo.Item", "BeautyHealthId");
            AddForeignKey("dbo.Item", "BeautyHealthId", "dbo.BeautyHealth", "BeautyhealthId");
            AddForeignKey("dbo.Item", "ClothingId", "dbo.Clothing", "ClothingId");
            AddForeignKey("dbo.Item", "HomeKitchenId", "dbo.HomeKitchen", "HomeKitchenId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "HomeKitchenId", "dbo.HomeKitchen");
            DropForeignKey("dbo.Item", "ClothingId", "dbo.Clothing");
            DropForeignKey("dbo.Item", "BeautyHealthId", "dbo.BeautyHealth");
            DropIndex("dbo.Item", new[] { "BeautyHealthId" });
            DropIndex("dbo.Item", new[] { "ClothingId" });
            DropIndex("dbo.Item", new[] { "HomeKitchenId" });
            AlterColumn("dbo.Item", "BeautyHealthId", c => c.Int(nullable: false));
            AlterColumn("dbo.Item", "ClothingId", c => c.Int(nullable: false));
            AlterColumn("dbo.Item", "HomeKitchenId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "BeautyHealthId");
            CreateIndex("dbo.Item", "ClothingId");
            CreateIndex("dbo.Item", "HomeKitchenId");
            AddForeignKey("dbo.Item", "HomeKitchenId", "dbo.HomeKitchen", "HomeKitchenId", cascadeDelete: true);
            AddForeignKey("dbo.Item", "ClothingId", "dbo.Clothing", "ClothingId", cascadeDelete: true);
            AddForeignKey("dbo.Item", "BeautyHealthId", "dbo.BeautyHealth", "BeautyhealthId", cascadeDelete: true);
        }
    }
}
