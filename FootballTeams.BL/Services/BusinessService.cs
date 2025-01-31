using FootballTeams.BL.Interfaces;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Requests;
using FootballTeams.Models.Responses;

namespace FootballTeams.BL.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IPlayerRepository _playerRepository;

        public BusinessService(ITeamsRepository teamsRepository, IPlayerRepository playerRepository)
        {
            _teamsRepository = teamsRepository;
            _playerRepository = playerRepository;
        }

        public TeamsFullDetailsResponse? GetAllTeamsByPlayers(AddTeamRequest request)
        {
            var teams = _teamsRepository.GetTeamByPlacement(request.Placement);
            var players = _playerRepository.GetById(request.PlayerId);

            if (players == null) return null;

            var result = new TeamsFullDetailsResponse
            {
                Players = players,
                Teams = teams
            };
            return result;
        }

        public int GetAllTeamsCount(int inputCount, int playerId)
        {
            if (inputCount == 0) return 0;
            var result = _teamsRepository.GetTeamByPlacement(playerId);

            return result.Count+ inputCount;
        }
    }
}

