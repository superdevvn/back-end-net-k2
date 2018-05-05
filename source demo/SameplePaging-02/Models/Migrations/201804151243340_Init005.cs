namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init005 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.User", "CreatedBy");
            AddForeignKey("dbo.User", "CreatedBy", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.User", "CreatedBy", "dbo.User");
            DropIndex("dbo.User", new[] { "CreatedBy" });
        }
    }
}
