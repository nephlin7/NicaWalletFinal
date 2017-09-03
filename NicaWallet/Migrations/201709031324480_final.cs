namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "AccountIcon", c => c.String());
            AlterColumn("dbo.Account", "AccountName", c => c.String(nullable: false));
            AlterColumn("dbo.Account", "CreatedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Account", "LastUpdate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Account", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Account", "Color", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Account", "Color", c => c.String());
            AlterColumn("dbo.Account", "IsActive", c => c.Boolean());
            AlterColumn("dbo.Account", "LastUpdate", c => c.DateTime());
            AlterColumn("dbo.Account", "CreatedDate", c => c.DateTime());
            AlterColumn("dbo.Account", "AccountName", c => c.String());
            DropColumn("dbo.Account", "AccountIcon");
        }
    }
}
