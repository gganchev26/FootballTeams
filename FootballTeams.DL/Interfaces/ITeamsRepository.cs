using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Interfaces
{
    public interface ITeamsRepository
    {
        Task<List<Teams>> GetAllTeamsFromPlayerAsync(int playerId);
    }
}