namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcolorfieldtoaccountmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "Color", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Account", "Color");
        }
    }
}
