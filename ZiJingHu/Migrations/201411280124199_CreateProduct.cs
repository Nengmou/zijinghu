namespace ZiJingHu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProduct : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Category = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Companies", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Companies", "ProductId");
            AddForeignKey("dbo.Companies", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Companies", "ProductId", "dbo.Products");
            DropIndex("dbo.Companies", new[] { "ProductId" });
            DropColumn("dbo.Companies", "ProductId");
            DropTable("dbo.Products");
        }
    }
}
