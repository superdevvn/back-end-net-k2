namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migra1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SubjectID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                        StartedDate = c.DateTime(nullable: false),
                        EndedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Subjects", t => t.SubjectID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.SubjectID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        Name = c.String(),
                        Credit = c.Int(nullable: false),
                        Fee = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .Index(t => t.Code, unique: true, name: "Subject_Code");
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Username)
                .Index(t => t.Code, unique: true, name: "Teacher_Code")
                .Index(t => t.Username);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Username);
            
            CreateTable(
                "dbo.StudentCourses",
                c => new
                    {
                        CourseID = c.Int(nullable: false),
                        StudentID = c.Int(nullable: false),
                        Practical = c.Single(nullable: false),
                        Middle = c.Single(nullable: false),
                        Final = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.CourseID, t.StudentID })
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.StudentID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(maxLength: 10),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Grade = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                        Username = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.Username)
                .Index(t => t.Code, unique: true, name: "Student_Code")
                .Index(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "Username", "dbo.Accounts");
            DropForeignKey("dbo.StudentCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.Courses", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Username", "dbo.Accounts");
            DropForeignKey("dbo.Courses", "SubjectID", "dbo.Subjects");
            DropIndex("dbo.Students", new[] { "Username" });
            DropIndex("dbo.Students", "Student_Code");
            DropIndex("dbo.StudentCourses", new[] { "StudentID" });
            DropIndex("dbo.StudentCourses", new[] { "CourseID" });
            DropIndex("dbo.Teachers", new[] { "Username" });
            DropIndex("dbo.Teachers", "Teacher_Code");
            DropIndex("dbo.Subjects", "Subject_Code");
            DropIndex("dbo.Courses", new[] { "TeacherID" });
            DropIndex("dbo.Courses", new[] { "SubjectID" });
            DropTable("dbo.Students");
            DropTable("dbo.StudentCourses");
            DropTable("dbo.Accounts");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Courses");
        }
    }
}
