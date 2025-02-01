using FootballTeams.Models.Request;
using FootballTeams.Models.Responses;

namespace FootballTeams.BL.Interfaces
{
    public interface IBusinessService
    {
        TeamsFullDetails? GetAllTeamsById(AddTeamRequest request);

        int GetAllTeamsCount(int inputCount, int playerId);
    }
}