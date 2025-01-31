using FootballTeams.Models.Requests;
using FootballTeams.Models.Responses;

namespace FootballTeams.BL.Interfaces
{
    public interface IBusinessService
    {
        TeamsFullDetailsResponse? GetAllTeamsByPlayers(AddTeamRequest request);

        int GetAllTeamsCount(int inputCount, int playerId);
    }
}
