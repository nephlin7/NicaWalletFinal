namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateamountfieldAccountmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Amount", c => c.Double(nullable: false));
            DropColumn("dbo.Account", "StartingAmount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Account", "StartingAmount", c => c.Double(nullable: false));
            DropColumn("dbo.Account", "Amount");
        }
    }
}
