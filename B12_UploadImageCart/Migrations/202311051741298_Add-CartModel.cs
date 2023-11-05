namespace B12_UploadImageCart.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCartModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProId, cascadeDelete: true)
                .Index(t => t.ProId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Carts", "ProId", "dbo.Products");
            DropIndex("dbo.Carts", new[] { "ProId" });
            DropTable("dbo.Carts");
        }
    }
}
