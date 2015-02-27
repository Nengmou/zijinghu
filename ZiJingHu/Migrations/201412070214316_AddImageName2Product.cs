namespace ZiJingHu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageName2Product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageName");
        }
    }
}
