namespace ZiJingHu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagePath2Client : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "ImageName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "ImageName");
        }
    }
}
