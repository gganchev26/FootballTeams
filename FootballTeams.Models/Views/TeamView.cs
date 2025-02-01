

using FootballTeams.Models.DTO;

namespace FootballTeams.Models.Views
{
    public class TeamView
    {
        public string TeamId { get; set; }
        public string TeamName { get; set; } = string.Empty;
        public IEnumerable<Players> Players { get; set; } = [];
    }
}
