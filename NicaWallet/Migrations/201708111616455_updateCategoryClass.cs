namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCategoryClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "ParentId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Category", "ParentId", c => c.Int(nullable: false));
        }
    }
}
