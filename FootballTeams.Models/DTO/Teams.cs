namespace FootballTeams.Models.DTO
{
    public class Teams
    {
        public string Id { get; set; }

        public int PlayerId { get; set; }
        public string TeamName { get; set; } = string.Empty;

        public List<string> Players { get; set; }
    }
}