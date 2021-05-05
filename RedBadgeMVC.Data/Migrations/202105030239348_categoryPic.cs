namespace RedBadgeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryPic : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "CategoryImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "CategoryImage");
        }
    }
}
