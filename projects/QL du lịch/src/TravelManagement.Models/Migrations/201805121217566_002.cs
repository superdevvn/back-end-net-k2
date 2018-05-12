namespace TravelManagement.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _002 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.TourDetail", "TourId");
            AddForeignKey("dbo.TourDetail", "TourId", "dbo.Tour", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TourDetail", "TourId", "dbo.Tour");
            DropIndex("dbo.TourDetail", new[] { "TourId" });
        }
    }
}
