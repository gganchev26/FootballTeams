using FootballTeams.BL.Interfaces;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;
using FootballTeams.Models.Responses;


namespace FootballTeams.BL.Services
{
    public class TeamsService : ITeamService
    {
        private readonly ITeamsRepository _teamRepository;


        public TeamsService(ITeamsRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public List<Teams> GetTeamByPlacement(int placement)
        {
            return _teamRepository.GetTeamByPlacement(placement);
        }
    }
}
