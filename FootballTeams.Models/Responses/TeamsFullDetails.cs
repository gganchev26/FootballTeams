using FootballTeams.Models.DTO;

namespace FootballTeams.Models.Responses
{
    public class TeamsFullDetailsResponse
    {
        public Players Players { get; set; }
        public List<Teams> Teams { get; set; }
    }
}
