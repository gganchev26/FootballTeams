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
               PlayerName = "Mitko",
               Age = 25,
            },
            new Players()
            {
               Id = 2,
               PlayerName = "Ivan",
               Age = 27,
            },
            new Players()
            {
               Id = 3,
               PlayerName = "Gosho",
               Age = 21,
            },
            new Players()
            {
               Id = 4,
               PlayerName = "Dragan",
               Age = 31,
            },
            new Players()
            {
               Id = 5,
               PlayerName = "Zhivko",
               Age = 42,
            },
        };

        public static List<Teams> TeamsData { get; set; } = new List<Teams>()
        {
            new Teams()
            {
                Id = "1",
                PlayerId = 1,
                TeamName = "Lokomotiv Plovdiv"
            },
            new Teams()
            {
                Id = "2",
                PlayerId = 2,
                TeamName = "Levski Sofia"
            },
            new Teams()
            {
                Id = "3",
                PlayerId = 3,
                TeamName = "CSKA-Sofia"
            },
            new Teams()
            {
                Id = "4",
                PlayerId = 4,
                TeamName = "Botev Plovdiv"
            },
            new Teams()
            {
                Id = "5",
                PlayerId = 5,
                TeamName = "Spartak Plovdiv"
            },
        };
    }
}