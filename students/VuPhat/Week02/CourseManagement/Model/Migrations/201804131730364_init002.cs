namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init002 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Courses", "TeacherId", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "Credit", c => c.Int(nullable: false));
            AddColumn("dbo.Subjects", "Price", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            DropColumn("dbo.Subjects", "Price");
            DropColumn("dbo.Subjects", "Credit");
            DropColumn("dbo.Courses", "TeacherId");
            DropTable("dbo.Teachers");
        }
    }
}
