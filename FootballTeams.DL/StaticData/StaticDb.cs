using FootballTeams.Models.DTO;

namespace FootballTeams.DL.StaticData
{
    internal static class StaticDb
    {
        public static List<Players> PlayersData { get; set; } = new List<Players>()
        {
            new Players()
            {
                Id = 1,
                Name = "Dimitar"
            },
            new Players()
            {
                Id= 2,
                Name = "Ivan"
            },
            new Players()
            {
                Id = 3,
                Name = "Ognyan"
            },
            new Players()
            {
                Id = 4,
                Name = "Ivelin"
            },
            new Players()
            {
                Id = 5,
                Name = "Birsent"
            },
            new Players()
            {
                Id = 6,
                Name = "Martin"
            }
        };

        public static List<Teams> TeamsData { get; set; } = new List<Teams>()
        {
            new Teams()
            {
                Id = "1",
                TeamName = "Lokomotiv",
                Placement = 1,
                ReleaseDate = DateTime.Now
            },
            new Teams()
            {
                Id = "2",
                TeamName = "Levski",
                Placement = 2,
                ReleaseDate = DateTime.Now
            },
            new Teams()
            {
                Id = "3",
                TeamName = "CSKA",
                Placement = 3,
                ReleaseDate = DateTime.Now
            },
            new Teams()
            {
                Id = "4",
                TeamName = "Botev",
                Placement = 4,
                ReleaseDate = DateTime.Now
            },
            new Teams()
            {
                Id = "5",
                TeamName = "Beroe",
                Placement = 5,
                ReleaseDate = DateTime.Now
            }
        };

    }
}
