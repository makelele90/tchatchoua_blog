namespace Blog.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _123 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PostComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateAdded = c.DateTime(nullable: false),
                        Post_Id = c.Int(),
                        Commenter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BlogPosts", t => t.Post_Id)
                .ForeignKey("dbo.Users", t => t.Commenter_Id)
                .Index(t => t.Post_Id)
                .Index(t => t.Commenter_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 250),
                        Password = c.String(nullable: false, maxLength: 250),
                        FirstName = c.String(nullable: false, maxLength: 250),
                        LastName = c.String(nullable: false, maxLength: 250),
                        Avatar = c.String(maxLength: 1000),
                        JoinDate = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 2000),
                        Details = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(),
                        CreatedBy_Id = c.Int(),
                        LastUpdatedBy_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Users", t => t.LastUpdatedBy_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.LastUpdatedBy_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostComments", "Commenter_Id", "dbo.Users");
            DropForeignKey("dbo.Roles", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BlogPosts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.BlogPosts", "LastUpdatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.BlogPosts", "CreatedBy_Id", "dbo.Users");
            DropForeignKey("dbo.PostComments", "Post_Id", "dbo.BlogPosts");
            DropIndex("dbo.Roles", new[] { "User_Id" });
            DropIndex("dbo.BlogPosts", new[] { "User_Id" });
            DropIndex("dbo.BlogPosts", new[] { "LastUpdatedBy_Id" });
            DropIndex("dbo.BlogPosts", new[] { "CreatedBy_Id" });
            DropIndex("dbo.PostComments", new[] { "Commenter_Id" });
            DropIndex("dbo.PostComments", new[] { "Post_Id" });
            DropTable("dbo.Roles");
            DropTable("dbo.BlogPosts");
            DropTable("dbo.Users");
            DropTable("dbo.PostComments");
        }
    }
}
