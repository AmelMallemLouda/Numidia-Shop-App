namespace RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "BeautyHealth_BeautyhealthId", "dbo.BeautyHealth");
            DropForeignKey("dbo.Item", "HomeKitchen_HomeKitchenId", "dbo.HomeKitchen");
            DropIndex("dbo.Item", new[] { "BeautyHealth_BeautyhealthId" });
            DropIndex("dbo.Item", new[] { "HomeKitchen_HomeKitchenId" });
            RenameColumn(table: "dbo.Item", name: "BeautyHealth_BeautyhealthId", newName: "BeautyHealthId");
            RenameColumn(table: "dbo.Item", name: "HomeKitchen_HomeKitchenId", newName: "HomeKitchenId");
            AlterColumn("dbo.Item", "BeautyHealthId", c => c.Int(nullable: false));
            AlterColumn("dbo.Item", "HomeKitchenId", c => c.Int(nullable: false));
            CreateIndex("dbo.Item", "HomeKitchenId");
            CreateIndex("dbo.Item", "BeautyHealthId");
            AddForeignKey("dbo.Item", "BeautyHealthId", "dbo.BeautyHealth", "BeautyhealthId", cascadeDelete: true);
            AddForeignKey("dbo.Item", "HomeKitchenId", "dbo.HomeKitchen", "HomeKitchenId", cascadeDelete: true);
            DropColumn("dbo.Item", "HomeId");
            DropColumn("dbo.Item", "BautyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "BautyId", c => c.Int(nullable: false));
            AddColumn("dbo.Item", "HomeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Item", "HomeKitchenId", "dbo.HomeKitchen");
            DropForeignKey("dbo.Item", "BeautyHealthId", "dbo.BeautyHealth");
            DropIndex("dbo.Item", new[] { "BeautyHealthId" });
            DropIndex("dbo.Item", new[] { "HomeKitchenId" });
            AlterColumn("dbo.Item", "HomeKitchenId", c => c.Int());
            AlterColumn("dbo.Item", "BeautyHealthId", c => c.Int());
            RenameColumn(table: "dbo.Item", name: "HomeKitchenId", newName: "HomeKitchen_HomeKitchenId");
            RenameColumn(table: "dbo.Item", name: "BeautyHealthId", newName: "BeautyHealth_BeautyhealthId");
            CreateIndex("dbo.Item", "HomeKitchen_HomeKitchenId");
            CreateIndex("dbo.Item", "BeautyHealth_BeautyhealthId");
            AddForeignKey("dbo.Item", "HomeKitchen_HomeKitchenId", "dbo.HomeKitchen", "HomeKitchenId");
            AddForeignKey("dbo.Item", "BeautyHealth_BeautyhealthId", "dbo.BeautyHealth", "BeautyhealthId");
        }
    }
}
