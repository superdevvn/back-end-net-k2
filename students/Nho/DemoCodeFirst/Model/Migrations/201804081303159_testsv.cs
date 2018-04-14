namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testsv : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        StartedDate = c.DateTime(nullable: false),
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
                        Decription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 100),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Grade = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Pratucal = c.Single(nullable: false),
                        Middle = c.Single(nullable: false),
                        Final = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseId, t.StudentId })
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.StudentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.Students", new[] { "Code" });
            DropIndex("dbo.Courses", new[] { "SubjectId" });
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Students");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
        }
    }
}
