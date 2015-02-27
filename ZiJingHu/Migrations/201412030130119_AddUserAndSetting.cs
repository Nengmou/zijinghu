namespace ZiJingHu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAndSetting : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Companies", newName: "Clients");
            RenameColumn(table: "dbo.Employees", name: "CompanyId", newName: "ClientId");
            RenameIndex(table: "dbo.Employees", name: "IX_CompanyId", newName: "IX_ClientId");
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        EmployeeId = c.Int(),
                        LastLoginDate = c.DateTime(),
                        LastLogoffDate = c.DateTime(),
                        IsAdmin = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        FailedLoginTimes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.EmployeeId);
            
            AddColumn("dbo.Clients", "Feedback", c => c.String());
            AddColumn("dbo.Employees", "Phone", c => c.String());
            AddColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Clients", "Website");
            DropColumn("dbo.Employees", "Age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "Website", c => c.String());
            DropForeignKey("dbo.Users", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Users", new[] { "EmployeeId" });
            AlterColumn("dbo.Employees", "Name", c => c.String());
            DropColumn("dbo.Employees", "Email");
            DropColumn("dbo.Employees", "Phone");
            DropColumn("dbo.Clients", "Feedback");
            DropTable("dbo.Users");
            DropTable("dbo.Settings");
            RenameIndex(table: "dbo.Employees", name: "IX_ClientId", newName: "IX_CompanyId");
            RenameColumn(table: "dbo.Employees", name: "ClientId", newName: "CompanyId");
            RenameTable(name: "dbo.Clients", newName: "Companies");
        }
    }
}
