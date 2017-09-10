namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCategroyicon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "CategoryIcon", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "CategoryIcon");
        }
    }
}
