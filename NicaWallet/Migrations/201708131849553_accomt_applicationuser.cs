namespace NicaWallet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class accomt_applicationuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Account", "User_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Phone", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            CreateIndex("dbo.Account", "User_Id");
            AddForeignKey("dbo.Account", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Account", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Account", new[] { "User_Id" });
            DropColumn("dbo.AspNetUsers", "BirthDate");
            DropColumn("dbo.AspNetUsers", "Phone");
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.Account", "User_Id");
        }
    }
}
