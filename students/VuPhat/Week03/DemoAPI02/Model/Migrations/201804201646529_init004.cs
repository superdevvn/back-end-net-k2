namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init004 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Code", c => c.String(maxLength: 15));
            AlterColumn("dbo.Role", "Code", c => c.String(maxLength: 15));
            AlterColumn("dbo.Manufacturer", "Code", c => c.String(maxLength: 15));
            AlterColumn("dbo.Product", "Code", c => c.String(maxLength: 15));
            CreateIndex("dbo.Category", "Code", unique: true);
            CreateIndex("dbo.Role", "Code", unique: true);
            CreateIndex("dbo.Manufacturer", "Code", unique: true);
            CreateIndex("dbo.Product", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Product", new[] { "Code" });
            DropIndex("dbo.Manufacturer", new[] { "Code" });
            DropIndex("dbo.Role", new[] { "Code" });
            DropIndex("dbo.Category", new[] { "Code" });
            AlterColumn("dbo.Product", "Code", c => c.String());
            AlterColumn("dbo.Manufacturer", "Code", c => c.String());
            AlterColumn("dbo.Role", "Code", c => c.String());
            AlterColumn("dbo.Category", "Code", c => c.String());
        }
    }
}
