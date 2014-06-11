using System;
using System.Collections.Generic;

namespace Blog.Data.Migrations
{

    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
          AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(BlogDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

          var users = new List<User> { 
             new User(){FirstName="francis",LastName="tchatchoua",JoinDate=DateTime.Today,LastLogin=DateTime.Today,UserName ="admin",Password = "1234"},
             new User(){FirstName="nounou",LastName="carine",JoinDate=DateTime.Today,LastLogin=DateTime.Today,UserName ="admin",Password = "1234"},
            new User(){FirstName="didier",LastName="njiki",JoinDate=DateTime.Today,LastLogin=DateTime.Today,UserName ="admin",Password = "1234"},
            new User(){FirstName="joanna",LastName="kamila",JoinDate=DateTime.Today,LastLogin=DateTime.Today,UserName ="admin",Password = "1234"},
            new User(){FirstName="mary",LastName="mbianga",JoinDate=DateTime.Today,LastLogin=DateTime.Today,UserName ="admin",Password = "1234"}
            };

          var roles = new List<Role>
            {
              new Role(){Name = "admin"},
              new Role(){Name = "editor"},
              new Role(){Name = "simple"}
            
            };
          foreach (var user in users)
          {
            context.Users.AddOrUpdate(user);
          }

          //Categories
          var categories = new List<Category>()
            {

              new Category() {Name = "Fitsness"},
              new Category() {Name = "ASP.NET MVC"},
              new Category() {Name = "C#"}
            };


          foreach (var cat in categories)
          {
            context.Categories.AddOrUpdate(cat);
          }
        }
    }
}
