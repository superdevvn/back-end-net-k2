namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoleId = c.Guid(nullable: false),
                        Username = c.String(),
                        HashedPassword = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Role");
        }
    }
}
