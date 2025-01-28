namespace FootballTeams.Models.DTO
{
    public class Teams
    {
        public string Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int Ranking { get; set; }

        public List<string> Players { get; set; }
    }
}