using FootballTeams.Models.DTO;

namespace FootballTeams.BL.Interfaces
{
    public interface ITeamService
    {
        List<Teams> GetAllTeamsFromPlayers(int playerId);
    }
}