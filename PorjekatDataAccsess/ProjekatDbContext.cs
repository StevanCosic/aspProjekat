using Microsoft.EntityFrameworkCore;
using System;
using ProjekatDomain;

namespace PorjekatDataAccsess
{
    public class ProjekatDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=group;Integrated Security=True");
        }

        public DbSet<group> group { get; set; }
        public DbSet<user> user { get; set; }
        public DbSet<useCaseLog> useCaseLog { get; set; }
        public DbSet<markaKola> markaKola { get; set; }
        public DbSet<tip_auta> tip_auto { get; set; }

        public DbSet<voznja> voznja { get; set; }

        public DbSet<vozac> vozac { get; set; }
        public DbSet<MessageForAdmin> MessageForAdmin { get; set; }



    }
}
