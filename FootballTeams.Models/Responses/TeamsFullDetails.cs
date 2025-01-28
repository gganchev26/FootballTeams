using FootballTeams.Models.DTO;

namespace FootballTeams.Models.Responses
{
    public class TeamsFullDetailsResponse
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Ranking { get; set; }

        public List<Players> Players { get; set; } = new List<Players>();
    }
}
