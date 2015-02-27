namespace ZiJingHu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateProduct1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Detail", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Detail");
        }
    }
}
