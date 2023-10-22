namespace B10_HTMLHelpers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        City = c.String(),
                        DepID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepID, cascadeDelete: true)
                .Index(t => t.DepID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DepID", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DepID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
