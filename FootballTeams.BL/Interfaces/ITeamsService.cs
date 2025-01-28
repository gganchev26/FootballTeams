using FootballTeams.Models.DTO;

namespace FootballTeams.BL.Interfaces
{
    public interface ITeamsService
    {
        List<Teams> GetAll();
        Teams? GetById(string id);

        void Add(Teams team);

        void AddPlayersToTeam(string teamId, string player);
    }
}