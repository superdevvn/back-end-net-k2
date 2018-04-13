namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
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
                        Code = c.String(maxLength: 15),
                        Name = c.String(maxLength: 50),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
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
                        Code = c.String(maxLength: 15),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Grade = c.String(maxLength: 50),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects");
            DropIndex("dbo.Students", new[] { "Code" });
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.Subjects", new[] { "Code" });
            DropIndex("dbo.Courses", new[] { "SubjectId" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
        }
    }
}
