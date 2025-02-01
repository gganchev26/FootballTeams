using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Interfaces
{
    public interface ITeamsRepository
    {
        List<Teams> GetAllTeamsFromPlayers(int playerId);
    }
}