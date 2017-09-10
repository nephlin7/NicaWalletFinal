namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addiconaccountdateInsertrecord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "AccountIcon", c => c.String());
            AddColumn("dbo.Record", "RecordDateInsert", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Record", "RecordDateInsert");
            DropColumn("dbo.Account", "AccountIcon");
        }
    }
}
