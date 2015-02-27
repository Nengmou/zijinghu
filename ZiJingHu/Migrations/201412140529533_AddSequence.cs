namespace ZiJingHu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSequence : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Sequence", c => c.Int());
            AddColumn("dbo.Products", "Sequence", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Sequence");
            DropColumn("dbo.Clients", "Sequence");
        }
    }
}
