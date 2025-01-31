namespace FootballTeams.Models.DTO
{
    public class Teams
    {
        public string Id { get; set; }

        public string TeamName { get; set; } = string.Empty;

        public int Placement { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<string> Players { get; set; }
    }
}