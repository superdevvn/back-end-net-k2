namespace Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _003 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Role", "Code", c => c.String(maxLength: 15));
            CreateIndex("dbo.Role", "Code", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Role", new[] { "Code" });
            AlterColumn("dbo.Role", "Code", c => c.String());
        }
    }
}
