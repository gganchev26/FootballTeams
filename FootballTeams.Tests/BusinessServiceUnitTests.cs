using FootballTeams.BL.Interfaces;
using FootballTeams.Models.DTO;
using FootballTeams.Models.Request;
using FootballTeams.Models.Responses;

namespace FootballTeams.BL.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly ITeamService _teamService;
        private readonly IPlayerService _playerService;

        public BusinessService(ITeamService teamService, IPlayerService playerService)
        {
            _teamService = teamService;
            _playerService = playerService;
        }

        public async Task<TeamsFullDetails?> GetAllTeamsByIdAsync(AddTeamRequest request)
        {
            var teams = await _teamService.GetAllTeamsFromPlayersAsync(request.Id);
            var player = await _playerService.GetByIdAsync(request.Id);

            if (player == null) return null;

            var result = new TeamsFullDetails
            {
                Players = player,
                Teams = teams.Where(g => g.TeamName == request.TeamName).ToList()
            };

            return result;
        }

        public async Task<int> GetAllTeamsCountAsync(int inputCount, int playerId)
        {
            if (inputCount <= 0) return 0;

            var result = await _teamService.GetAllTeamsFromPlayersAsync(playerId);
            return result.Count + inputCount;
        }
    }
}
