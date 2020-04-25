using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Racing_team_management.Models;
using Microsoft.EntityFrameworkCore;

namespace Racing_team_management.Contexts
{
    public class Context : DbContext
    {
        public DbSet<Component> Components { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamComponent> TeamComponents { get; set; }
        public DbSet<TeamRace> TeamRaces { get; set; }
        public static bool isMigration = true;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
                optionsBuilder.UseSqlServer(@"Server=.\;Database=DBRacing_team_managment;Trusted_Connection=True;");
        }
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
