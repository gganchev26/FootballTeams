namespace FootballTeams.Models.Requests
{
    public class AddTeamRequest
    {
        public string Name { get; set; } = string.Empty;

        public int Placement { get; set; }

        public int PlayerId { get; set; }

        public DateTime AfterDate { get; set; }
    }
}
