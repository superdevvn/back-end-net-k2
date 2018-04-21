namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        PassWord = c.String(),
                        StudentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accounts", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Accounts", "StudentId", "dbo.Students");
            DropIndex("dbo.Accounts", new[] { "TeacherId" });
            DropIndex("dbo.Accounts", new[] { "StudentId" });
            DropTable("dbo.Accounts");
        }
    }
}
