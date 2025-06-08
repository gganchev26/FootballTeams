using FootballTeams.Models.DTO;

namespace FootballTeams.BL.Interfaces
{
    public interface ITeamService
    {
        Task<List<Teams>> GetAllTeamsFromPlayersAsync(int playerId);
    }
}