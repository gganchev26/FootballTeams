namespace FootballTeams.Models.Requests
{
    public class AddTeamRequest
    {
        public string Name { get; set; } = string.Empty;
        public int Ranking { get; set; }
    }
}
