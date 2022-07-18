using Microsoft.EntityFrameworkCore;
using Dominio.Entities;

namespace Infrastructure
{
    public class DataContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Prediction> Predictions { get; set; }

        public DataContext(DbContextOptions options)
            : base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.SeedTeams();
            builder.SeedMatches();
        }
    }
}
