namespace Blog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BlogPosts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.BlogPosts", new[] { "CategoryId" });
            AlterColumn("dbo.BlogPosts", "CategoryId", c => c.Int());
            CreateIndex("dbo.BlogPosts", "CategoryId");
            AddForeignKey("dbo.BlogPosts", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogPosts", "CategoryId", "dbo.Categories");
            DropIndex("dbo.BlogPosts", new[] { "CategoryId" });
            AlterColumn("dbo.BlogPosts", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.BlogPosts", "CategoryId");
            AddForeignKey("dbo.BlogPosts", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
