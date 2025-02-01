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

        public BusinessService(ITeamService teamservice, IPlayerService playerService)
        {
            _teamService = teamservice;
            _playerService = playerService;
        }

        public TeamsFullDetails? GetAllTeamsById(AddTeamRequest request)
        {
            var teams = _teamService.GetAllTeamsFromPlayers(request.Id);

            var players = _playerService.GetById(request.Id);

            if (players == null) return null;

            var result = new TeamsFullDetails
            {
                Players = players,
                Teams = teams.Where(g => g.TeamName == request.TeamName).ToList()
            };
            return result;
        }

        public int GetAllTeamsCount(int inputCount, int playerId)
        {
            if (inputCount <= 0) return 0;

            var result = _teamService.GetAllTeamsFromPlayers(playerId);
            return result.Count + inputCount;
        }
    }
}