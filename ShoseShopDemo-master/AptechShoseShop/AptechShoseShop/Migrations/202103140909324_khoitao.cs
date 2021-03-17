namespace AptechShoseShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class khoitao : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductImages", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductImage_Id", "dbo.ProductImages");
            DropForeignKey("dbo.Products", "ProductImageId", "dbo.ProductImages");
            DropForeignKey("dbo.ProductImages", "Product_Id", "dbo.Products");
            DropIndex("dbo.Products", new[] { "ProductImageId" });
            DropIndex("dbo.Products", new[] { "ProductImage_Id" });
            DropIndex("dbo.ProductImages", new[] { "ProductId" });
            DropIndex("dbo.ProductImages", new[] { "Product_Id" });
            DropColumn("dbo.Products", "ProductImage_Id");
            DropTable("dbo.ProductImages");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Products", "ProductImage_Id", c => c.Int());
            CreateIndex("dbo.ProductImages", "Product_Id");
            CreateIndex("dbo.ProductImages", "ProductId");
            CreateIndex("dbo.Products", "ProductImage_Id");
            CreateIndex("dbo.Products", "ProductImageId");
            AddForeignKey("dbo.ProductImages", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Products", "ProductImageId", "dbo.ProductImages", "Id");
            AddForeignKey("dbo.Products", "ProductImage_Id", "dbo.ProductImages", "Id");
            AddForeignKey("dbo.ProductImages", "ProductId", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
