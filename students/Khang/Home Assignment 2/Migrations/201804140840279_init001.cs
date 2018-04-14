namespace Home_Assignment_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Fee = c.Int(nullable: false),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Practical = c.Int(nullable: false),
                        Middle = c.Int(nullable: false),
                        Final = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.StudentId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        FristName = c.String(),
                        LastName = c.String(),
                        Grade = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.UserName)
                .Index(t => t.UserName);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        FristName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        UserName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.UserName)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.SubjectId)
                .Index(t => t.UserName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Teachers", "UserName", "dbo.Accounts");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "UserName", "dbo.Accounts");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Teachers", new[] { "UserName" });
            DropIndex("dbo.Teachers", new[] { "SubjectId" });
            DropIndex("dbo.Students", new[] { "UserName" });
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "SubjectId" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Students");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
            DropTable("dbo.Accounts");
        }
    }
}
