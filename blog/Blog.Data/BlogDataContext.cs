using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Blog.Data
{
    public class BlogDataContext:DbContext
    {
        public BlogDataContext():base("BlogConnectionString")
        {
            Database.SetInitializer<BlogDataContext>(new BlogDbInitializer());
        }
        public DbSet<BlogPost> Posts { get; set; }
        public DbSet<PostComment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //User
            modelBuilder.Entity<User>().Property(e => e.FirstName).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.LastName).HasMaxLength(250).IsRequired();
            modelBuilder.Entity<User>().Property(e => e.Avatar).HasMaxLength(1000);


            //BlogPost
            modelBuilder.Entity<BlogPost>().Property(e => e.Title).HasMaxLength(2000).IsRequired();
            modelBuilder.Entity<BlogPost>().Property(e => e.Details).IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
