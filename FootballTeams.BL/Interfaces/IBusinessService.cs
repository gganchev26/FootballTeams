using FootballTeams.Models.Responses;

namespace FootballTeams.BL.Interfaces
{
    public interface IBusinessService
    {
        List<TeamsFullDetailsResponse> GetAllTeams();
    }
}
