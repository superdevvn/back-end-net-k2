namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init002 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Code", c => c.String(maxLength: 15));
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 100));
            CreateIndex("dbo.Products", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Code" });
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Code", c => c.String());
        }
    }
}
