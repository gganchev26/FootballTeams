using FootballTeams.Models.DTO;

namespace FootballTeams.Models.Responses
{
    public class TeamsFullDetails
    {
        public Players Players { get; set; }

        public List<Teams> Teams { get; set; }
    }
}