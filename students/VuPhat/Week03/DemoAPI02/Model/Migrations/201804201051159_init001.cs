namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "ModifiedBy", "dbo.User");
            DropIndex("dbo.Role", new[] { "CreatedBy" });
            DropIndex("dbo.Role", new[] { "ModifiedBy" });
            DropIndex("dbo.User", new[] { "ModifiedBy" });
            AlterColumn("dbo.Role", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.Role", "ModifiedBy", c => c.Guid());
            AlterColumn("dbo.User", "CreatedBy", c => c.Guid());
            AlterColumn("dbo.User", "ModifiedBy", c => c.Guid());
            CreateIndex("dbo.Role", "CreatedBy");
            CreateIndex("dbo.Role", "ModifiedBy");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Role", new[] { "ModifiedBy" });
            DropIndex("dbo.Role", new[] { "CreatedBy" });
            AlterColumn("dbo.User", "ModifiedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.User", "CreatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.Role", "ModifiedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.Role", "CreatedBy", c => c.Guid(nullable: false));
            CreateIndex("dbo.User", "ModifiedBy");
            CreateIndex("dbo.Role", "ModifiedBy");
            CreateIndex("dbo.Role", "CreatedBy");
            AddForeignKey("dbo.User", "ModifiedBy", "dbo.User", "Id");
        }
    }
}
