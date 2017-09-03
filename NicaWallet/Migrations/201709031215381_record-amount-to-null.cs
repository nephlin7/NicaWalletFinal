namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recordamounttonull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Record", "Amount", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Record", "Amount", c => c.Double(nullable: false));
        }
    }
}
