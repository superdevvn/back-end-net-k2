namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init005 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accounts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Accounts", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Accounts", new[] { "StudentId" });
            DropIndex("dbo.Accounts", new[] { "TeacherId" });
            AlterColumn("dbo.Accounts", "StudentId", c => c.Int());
            AlterColumn("dbo.Accounts", "TeacherId", c => c.Int());
            CreateIndex("dbo.Accounts", "StudentId");
            CreateIndex("dbo.Accounts", "TeacherId");
            AddForeignKey("dbo.Accounts", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.Accounts", "TeacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Accounts", "StudentId", "dbo.Students");
            DropIndex("dbo.Accounts", new[] { "TeacherId" });
            DropIndex("dbo.Accounts", new[] { "StudentId" });
            AlterColumn("dbo.Accounts", "TeacherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Accounts", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Accounts", "TeacherId");
            CreateIndex("dbo.Accounts", "StudentId");
            AddForeignKey("dbo.Accounts", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Accounts", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
    }
}
