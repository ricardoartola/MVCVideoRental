namespace MVCVideoRental.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using MVCVideoRental.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCVideoRental.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCVideoRental.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == RoleName.CanManage))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = RoleName.CanManage };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@admin.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@admin.com" };

                manager.Create(user, "SecretPass1!");
                manager.AddToRole(user.Id, RoleName.CanManage);
            }

            context.Genres.AddOrUpdate(
                new Genre() { Name = "Action", Id = 1 },
                new Genre() { Name = "Thriller", Id = 2 },
                new Genre() { Name = "Family", Id = 3 },
                new Genre() { Name = "Romance", Id = 4 },
                new Genre() { Name = "Comedy", Id = 5 }
                );
            context.SaveChanges();

        }
    }
}
