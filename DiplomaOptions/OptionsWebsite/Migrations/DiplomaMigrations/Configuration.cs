namespace OptionsWebsite.Migrations.DiplomaMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using DiplomaDataModel;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OptionsWebsite.DataContext.DiplomaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\DiplomaMigrations";
        }

        protected override void Seed(OptionsWebsite.DataContext.DiplomaContext context)
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
          if (!context.YearTerms.Any() || !context.Options.Any())
            {
                context.YearTerms.AddOrUpdate(
                   p => p.YearTermId,
                   new YearTerm { Year = 2015, Term = 20, isDefault = false },
                   new YearTerm { Year = 2015, Term = 30, isDefault = false },
                   new YearTerm { Year = 2016, Term = 10, isDefault = false },
                   new YearTerm { Year = 2016, Term = 30, isDefault = true }
           );

                context.SaveChanges();

                context.Options.AddOrUpdate(
                        p => p.OptionId,
                        new Option { Title = "Data Communications", isActive = true },
                        new Option { Title = "Client Server", isActive = true },
                        new Option { Title = "Digital Processing", isActive = true },
                        new Option { Title = "Information Systems", isActive = true },
                        new Option { Title = "Database", isActive = false },
                        new Option { Title = "Web & Mobile", isActive = true },
                        new Option { Title = "Tech Pro", isActive = false }
               );

                context.SaveChanges();
            }

        }
           
    }
}
