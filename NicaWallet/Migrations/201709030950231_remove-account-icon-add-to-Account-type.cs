namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeaccounticonaddtoAccounttype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccountType", "AccountIcon", c => c.String());
            DropColumn("dbo.Account", "AccountIcon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Account", "AccountIcon", c => c.String());
            DropColumn("dbo.AccountType", "AccountIcon");
        }
    }
}
