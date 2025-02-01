namespace FootballTeams.Models.Request
{
    public class AddTeamRequest
    {
        public string TeamName { get; set; } = string.Empty;
        public int Id { get; set; }
    }
}