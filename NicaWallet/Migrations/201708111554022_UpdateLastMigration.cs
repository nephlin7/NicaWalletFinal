namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateLastMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Account", "AccountTypeId", "dbo.AccountType");
            DropForeignKey("dbo.Account", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Record", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Record", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Record", "CurrencyId", "dbo.Currency");
            DropIndex("dbo.Account", new[] { "CurrencyId" });
            DropIndex("dbo.Account", new[] { "AccountTypeId" });
            DropIndex("dbo.Record", new[] { "AccountId" });
            DropIndex("dbo.Record", new[] { "CurrencyId" });
            DropIndex("dbo.Record", new[] { "CategoryId" });
            AlterColumn("dbo.Account", "CurrencyId", c => c.Int());
            AlterColumn("dbo.Account", "AccountTypeId", c => c.Int());
            AlterColumn("dbo.Record", "AccountId", c => c.Int());
            AlterColumn("dbo.Record", "CurrencyId", c => c.Int());
            AlterColumn("dbo.Record", "CategoryId", c => c.Int());
            CreateIndex("dbo.Account", "CurrencyId");
            CreateIndex("dbo.Account", "AccountTypeId");
            CreateIndex("dbo.Record", "AccountId");
            CreateIndex("dbo.Record", "CurrencyId");
            CreateIndex("dbo.Record", "CategoryId");
            AddForeignKey("dbo.Account", "AccountTypeId", "dbo.AccountType", "AccountTypeId");
            AddForeignKey("dbo.Account", "CurrencyId", "dbo.Currency", "CurrencyId");
            AddForeignKey("dbo.Record", "AccountId", "dbo.Account", "AccountId");
            AddForeignKey("dbo.Record", "CategoryId", "dbo.Category", "CategoryId");
            AddForeignKey("dbo.Record", "CurrencyId", "dbo.Currency", "CurrencyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Record", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Record", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Record", "AccountId", "dbo.Account");
            DropForeignKey("dbo.Account", "CurrencyId", "dbo.Currency");
            DropForeignKey("dbo.Account", "AccountTypeId", "dbo.AccountType");
            DropIndex("dbo.Record", new[] { "CategoryId" });
            DropIndex("dbo.Record", new[] { "CurrencyId" });
            DropIndex("dbo.Record", new[] { "AccountId" });
            DropIndex("dbo.Account", new[] { "AccountTypeId" });
            DropIndex("dbo.Account", new[] { "CurrencyId" });
            AlterColumn("dbo.Record", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Record", "CurrencyId", c => c.Int(nullable: false));
            AlterColumn("dbo.Record", "AccountId", c => c.Int(nullable: false));
            AlterColumn("dbo.Account", "AccountTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Account", "CurrencyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Record", "CategoryId");
            CreateIndex("dbo.Record", "CurrencyId");
            CreateIndex("dbo.Record", "AccountId");
            CreateIndex("dbo.Account", "AccountTypeId");
            CreateIndex("dbo.Account", "CurrencyId");
            AddForeignKey("dbo.Record", "CurrencyId", "dbo.Currency", "CurrencyId", cascadeDelete: true);
            AddForeignKey("dbo.Record", "CategoryId", "dbo.Category", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Record", "AccountId", "dbo.Account", "AccountId", cascadeDelete: true);
            AddForeignKey("dbo.Account", "CurrencyId", "dbo.Currency", "CurrencyId", cascadeDelete: true);
            AddForeignKey("dbo.Account", "AccountTypeId", "dbo.AccountType", "AccountTypeId", cascadeDelete: true);
        }
    }
}
