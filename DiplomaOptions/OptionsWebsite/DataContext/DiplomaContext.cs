using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiplomaDataModel;

namespace OptionsWebsite.DataContext
{
    class DiplomaContext : DbContext
    {
        public DiplomaContext() : base("DefaultConnection") { }

        public DbSet<YearTerm> YearTerms { get; set; }

        public DbSet<Choice> Choices { get; set; }

        public DbSet<Option> Options { get; set; }

    }
}
