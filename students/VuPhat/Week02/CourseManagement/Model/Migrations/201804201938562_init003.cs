namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init003 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Birthday", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Birthday");
        }
    }
}
