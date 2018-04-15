namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init004 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Role", "CreatedBy");
            CreateIndex("dbo.Role", "ModifiedBy");
            AddForeignKey("dbo.Role", "CreatedBy", "dbo.User", "Id");
            AddForeignKey("dbo.Role", "ModifiedBy", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Role", "ModifiedBy", "dbo.User");
            DropForeignKey("dbo.Role", "CreatedBy", "dbo.User");
            DropIndex("dbo.Role", new[] { "ModifiedBy" });
            DropIndex("dbo.Role", new[] { "CreatedBy" });
        }
    }
}
