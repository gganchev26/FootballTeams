using FootballTeams.Models.DTO;

namespace FootballTeams.DL.StaticData
{
    internal static class StaticDb
    {
        public static List<Players> Players { get; set; } = new List<Players>()
        {
            new Players()
            {
               Id = "1",
                Name = "Dimitar Iliev"
            },
            new Players()
            {
                Id = "2",
                Name = "Birsent Karageren"
            },
            new Players()
            {
                Id = "3",
                Name = "Angel Liaskov"
            }
        };

        public static List<Teams> Teams { get; set; } = new List<Teams>()
        {
            new Teams()
            {
                Id = "1",
                Name = "Lokomotiv Plovidv",
                Ranking = 1,
            },
            new Teams()
            {
                Id = "2",
                Name = "Levski Sofia",
                Ranking = 2,
            },

            new Teams()
            {
                Id = "3",
                Name = "Lokomotiv Sofia",
                Ranking = 3,
            }
        };

    }
}
