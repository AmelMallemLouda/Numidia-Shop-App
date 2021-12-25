namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trans : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "FullName", c => c.String(nullable: false));
        }
    }
}
