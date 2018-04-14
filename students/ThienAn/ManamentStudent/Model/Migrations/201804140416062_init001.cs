namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init001 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropIndex("dbo.Courses", new[] { "SubjectId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropPrimaryKey("dbo.Courses");
            DropPrimaryKey("dbo.Subjects");
            DropPrimaryKey("dbo.StudentCourses");
            DropPrimaryKey("dbo.Students");
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Sdt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.TeacherAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.AccountId);
            
            AddColumn("dbo.Courses", "TeacherId", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "SoTinChi", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "HocPhi", c => c.Double(nullable: false));
            AlterColumn("dbo.Courses", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Courses", "SubjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Subjects", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.StudentCourses", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.StudentCourses", "CourseId", c => c.Int(nullable: false));
            AlterColumn("dbo.StudentCourses", "StudentId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Courses", "Id");
            AddPrimaryKey("dbo.Subjects", "Id");
            AddPrimaryKey("dbo.StudentCourses", "Id");
            AddPrimaryKey("dbo.Students", "Id");
            CreateIndex("dbo.Courses", "SubjectId");
            CreateIndex("dbo.Courses", "TeacherId");
            CreateIndex("dbo.StudentCourses", "CourseId");
            CreateIndex("dbo.StudentCourses", "StudentId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.TeacherAccounts", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.TeacherAccounts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.StudentAccounts", "StudentId", "dbo.Students");
            DropForeignKey("dbo.StudentAccounts", "AccountId", "dbo.Accounts");
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.TeacherAccounts", new[] { "AccountId" });
            DropIndex("dbo.TeacherAccounts", new[] { "TeacherId" });
            DropIndex("dbo.StudentCourses", new[] { "StudentId" });
            DropIndex("dbo.StudentCourses", new[] { "CourseId" });
            DropIndex("dbo.StudentAccounts", new[] { "AccountId" });
            DropIndex("dbo.StudentAccounts", new[] { "StudentId" });
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropIndex("dbo.Courses", new[] { "SubjectId" });
            DropPrimaryKey("dbo.Students");
            DropPrimaryKey("dbo.StudentCourses");
            DropPrimaryKey("dbo.Subjects");
            DropPrimaryKey("dbo.Courses");
            AlterColumn("dbo.Students", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.StudentCourses", "StudentId", c => c.String(maxLength: 128));
            AlterColumn("dbo.StudentCourses", "CourseId", c => c.String(maxLength: 128));
            AlterColumn("dbo.StudentCourses", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Subjects", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Courses", "SubjectId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Subjects", "HocPhi");
            DropColumn("dbo.Subjects", "SoTinChi");
            DropColumn("dbo.Courses", "TeacherId");
            DropTable("dbo.TeacherAccounts");
            DropTable("dbo.StudentAccounts");
            DropTable("dbo.Teachers");
            DropTable("dbo.Accounts");
            AddPrimaryKey("dbo.Students", "Id");
            AddPrimaryKey("dbo.StudentCourses", "Id");
            AddPrimaryKey("dbo.Subjects", "Id");
            AddPrimaryKey("dbo.Courses", "Id");
            CreateIndex("dbo.StudentCourses", "StudentId");
            CreateIndex("dbo.StudentCourses", "CourseId");
            CreateIndex("dbo.Courses", "SubjectId");
            AddForeignKey("dbo.StudentCourses", "StudentId", "dbo.Students", "Id");
            AddForeignKey("dbo.StudentCourses", "CourseId", "dbo.Courses", "Id");
            AddForeignKey("dbo.Courses", "SubjectId", "dbo.Subjects", "Id");
        }
    }
}
