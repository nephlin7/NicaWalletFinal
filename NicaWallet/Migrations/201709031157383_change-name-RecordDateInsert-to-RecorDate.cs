namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changenameRecordDateInserttoRecorDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Record", "RecordDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Record", "RecordDateInsert");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Record", "RecordDateInsert", c => c.DateTime(nullable: false));
            DropColumn("dbo.Record", "RecordDate");
        }
    }
}
