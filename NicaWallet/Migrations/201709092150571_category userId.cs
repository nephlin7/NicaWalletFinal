namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoryuserId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Category", "UserId");
        }
    }
}
