using Dominio.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public static class ModelBuilderSeeds
    {
        public static void SeedTeams(this ModelBuilder builder)
        {
            string filePath = "teams_data.csv";

            var teams = new List<Team>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                var fields = line.Split(";");
                teams.Add(new Team
                {
                    Id = int.Parse(fields[0]),
                    Deleted = false,
                    Name = fields[2],
                    Group = fields[3][0]
                });
            }

            builder.Entity<Team>().HasData(teams);
        }

        public static void SeedMatches(this ModelBuilder builder)
        {
            string filePath = "matchs_data.csv";

            var matches = new List<Match>();

            foreach (var line in File.ReadAllLines(filePath))
            {
                var fields = line.Split(";");
                matches.Add(new Match
                {
                    Id = int.Parse(fields[0]),
                    Deleted = false,
                    Code = fields[5],
                    LocalId = int.Parse(fields[3]),
                    VisitId = int.Parse(fields[4]),
                    LocalScore = 0,
                    VisitScore = 0,
                    Date = DateTime.Parse(fields[2])
                });
            }

            builder.Entity<Match>().HasData(matches);
        }
    }
}
