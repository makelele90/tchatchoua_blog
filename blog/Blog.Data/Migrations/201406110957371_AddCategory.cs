namespace Blog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BlogPosts", "Category_Id", c => c.Int());
            CreateIndex("dbo.BlogPosts", "Category_Id");
            AddForeignKey("dbo.BlogPosts", "Category_Id", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "Category_Id", "dbo.Categories");
            DropIndex("dbo.BlogPosts", new[] { "Category_Id" });
            DropColumn("dbo.BlogPosts", "Category_Id");
            DropTable("dbo.Categories");
        }
    }
}
