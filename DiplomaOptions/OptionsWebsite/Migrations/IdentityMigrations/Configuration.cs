namespace OptionsWebsite.Migrations.IdentityMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<OptionsWebsite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\IdentityMigrations";
        }

        protected override void Seed(OptionsWebsite.Models.ApplicationDbContext context)
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
            if (!context.Users.Any())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

                string[] emails = { "a@a.a", "s@s.s" };
                string[] users = { "A00111111", "A00222222" };

                if (!roleManager.RoleExists("Admin"))
                    roleManager.Create(new IdentityRole("Admin"));

                if (!roleManager.RoleExists("Student"))
                    roleManager.Create(new IdentityRole("Student"));

                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                if (userManager.FindByEmail(emails[0]) == null)
                {
                    var user = new ApplicationUser
                    {
                        Email = emails[0],
                        UserName = users[0],
                    };
                    var result = userManager.Create(user, "P@$$w0rd");
                    if (result.Succeeded)
                        userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Admin");
                }
                if (userManager.FindByEmail(emails[1]) == null)
                {
                    var user = new ApplicationUser
                    {
                        Email = emails[1],
                        UserName = users[1],
                    };
                    var result = userManager.Create(user, "P@$$w0rd");
                    if (result.Succeeded)
                        userManager.AddToRole(userManager.FindByEmail(user.Email).Id, "Student");
                }
            }
            
        }
    }
}
