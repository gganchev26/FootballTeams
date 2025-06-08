using FootballTeams.Models.Request;
using FootballTeams.Models.Responses;

namespace FootballTeams.BL.Interfaces
{
    public interface IBusinessService
    {
        Task<TeamsFullDetails?> GetAllTeamsByIdAsync(AddTeamRequest request);
        Task<int> GetAllTeamsCountAsync(int inputCount, int playerId);
    }
}