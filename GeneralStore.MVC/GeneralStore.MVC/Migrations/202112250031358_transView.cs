namespace GeneralStore.MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transView : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Transactions", "DateOfTransaction", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Transactions", "DateOfTransaction", c => c.DateTime(nullable: false));
        }
    }
}
