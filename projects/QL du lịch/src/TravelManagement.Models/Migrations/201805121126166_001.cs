namespace TravelManagement.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TourDetail",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TourId = c.Guid(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tour",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        AdultPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ChildPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Policy = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tour");
            DropTable("dbo.TourDetail");
        }
    }
}
