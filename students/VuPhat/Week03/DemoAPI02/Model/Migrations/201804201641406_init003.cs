namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init003 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.User", t => t.ModifiedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy);
            
            CreateTable(
                "dbo.Manufacturer",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.User", t => t.ModifiedBy)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        CategoryId = c.Guid(nullable: false),
                        ManufacturerId = c.Guid(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(),
                        ModifiedDate = c.DateTime(nullable: false),
                        ModifiedBy = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryId)
                .ForeignKey("dbo.User", t => t.CreatedBy)
                .ForeignKey("dbo.Manufacturer", t => t.ManufacturerId)
                .ForeignKey("dbo.User", t => t.ModifiedBy)
                .Index(t => t.CategoryId)
                .Index(t => t.ManufacturerId)
                .Index(t => t.CreatedBy)
                .Index(t => t.ModifiedBy);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ModifiedBy", "dbo.User");
            DropForeignKey("dbo.Product", "ManufacturerId", "dbo.Manufacturer");
            DropForeignKey("dbo.Product", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.Product", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.Manufacturer", "ModifiedBy", "dbo.User");
            DropForeignKey("dbo.Manufacturer", "CreatedBy", "dbo.User");
            DropForeignKey("dbo.Category", "ModifiedBy", "dbo.User");
            DropForeignKey("dbo.Category", "CreatedBy", "dbo.User");
            DropIndex("dbo.Product", new[] { "ModifiedBy" });
            DropIndex("dbo.Product", new[] { "CreatedBy" });
            DropIndex("dbo.Product", new[] { "ManufacturerId" });
            DropIndex("dbo.Product", new[] { "CategoryId" });
            DropIndex("dbo.Manufacturer", new[] { "ModifiedBy" });
            DropIndex("dbo.Manufacturer", new[] { "CreatedBy" });
            DropIndex("dbo.Category", new[] { "ModifiedBy" });
            DropIndex("dbo.Category", new[] { "CreatedBy" });
            DropTable("dbo.Product");
            DropTable("dbo.Manufacturer");
            DropTable("dbo.Category");
        }
    }
}
