namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PaymentTypenotnull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Record", "PaymentType", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Record", "PaymentType", c => c.Boolean());
        }
    }
}
