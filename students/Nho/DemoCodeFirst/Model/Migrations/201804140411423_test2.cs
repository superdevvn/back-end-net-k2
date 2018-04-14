namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 100),
                        FirstName = c.String(),
                        LastName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.UserName)
                .Index(t => t.Code, unique: true)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
            AddColumn("dbo.Courses", "TeacherId", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "Credit", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "fee", c => c.Single(nullable: false));
            AddColumn("dbo.Students", "UserName", c => c.String(maxLength: 128));
            CreateIndex("dbo.Courses", "TeacherId");
            CreateIndex("dbo.Students", "UserName");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Students", "UserName", "dbo.Accounts", "UserName");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "UserName", "dbo.Accounts");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "UserName", "dbo.Accounts");
            DropIndex("dbo.Students", new[] { "UserName" });
            DropIndex("dbo.Teachers", new[] { "UserName" });
            DropIndex("dbo.Teachers", new[] { "Code" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropColumn("dbo.Students", "UserName");
            DropColumn("dbo.Subjects", "fee");
            DropColumn("dbo.Subjects", "Credit");
            DropColumn("dbo.Courses", "TeacherId");
            DropTable("dbo.Accounts");
            DropTable("dbo.Teachers");
        }
    }
}
