using FootballTeams.BL.Interfaces;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;

namespace FootballTeams.BL.Services
{
    public class TeamsService : ITeamService
    {
        private readonly ITeamsRepository _teamsrepository;

        public TeamsService(ITeamsRepository teamsRepository)
        {
            _teamsrepository = teamsRepository;
        }

        public async Task<List<Teams>> GetAllTeamsFromPlayersAsync(int playerId)
        {
            return await _teamsrepository.GetAllTeamsFromPlayerAsync(playerId);
        }
    }
}