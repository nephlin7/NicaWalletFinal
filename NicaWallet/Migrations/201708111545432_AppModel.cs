namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        StartingAmount = c.Double(nullable: false),
                        CreatedDate = c.DateTime(),
                        LastUpdate = c.DateTime(),
                        IsActive = c.Boolean(),
                        CurrencyId = c.Int(nullable: false),
                        AccountTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccountId)
                .ForeignKey("dbo.AccountType", t => t.AccountTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: false)
                .Index(t => t.CurrencyId)
                .Index(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.AccountType",
                c => new
                    {
                        AccountTypeId = c.Int(nullable: false, identity: true),
                        AccountTypeName = c.String(),
                    })
                .PrimaryKey(t => t.AccountTypeId);
            
            CreateTable(
                "dbo.Currency",
                c => new
                    {
                        CurrencyId = c.Int(nullable: false, identity: true),
                        CurrencyName = c.String(),
                        IsBaseCurrency = c.Boolean(),
                    })
                .PrimaryKey(t => t.CurrencyId);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        ParentId = c.Int(nullable: false),
                        IsParent = c.Boolean(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Record",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Note = c.String(),
                        PaymentType = c.Boolean(),
                        AccountId = c.Int(nullable: false),
                        CurrencyId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Account", t => t.AccountId, cascadeDelete: false)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: false)
                .ForeignKey("dbo.Currency", t => t.CurrencyId, cascadeDelete: false)
                .Index(t => t.AccountId)
                .Index(t => t.CurrencyId)
                .Index(t => t.CategoryId);
            
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
            DropTable("dbo.Record");
            DropTable("dbo.Category");
            DropTable("dbo.Currency");
            DropTable("dbo.AccountType");
            DropTable("dbo.Account");
        }
    }
}
