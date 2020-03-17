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
        public DbSet<Components> Albums { get; set; }
        public DbSet<Employee> Artists { get; set; }
        public DbSet<Manufacturer> ArtistAlbums { get; set; }
        public DbSet<Race> Providers { get; set; }
        public DbSet<Team> Songs { get; set; }
        public DbSet<TeamComponents> SongAlbums { get; set; }
        public DbSet<TeamRace> Studios { get; set; }
        public static bool isMigration = true;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isMigration)
                optionsBuilder.UseSqlServer(@"Server=.\;Database=DBRacing_team_managment;Trusted_Conection=True;");
        }
        public Context()
        {

        }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
    }
}
