using Microsoft.Extensions.Logging;
using FootballTeams.BL.Interfaces;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;
using System.Runtime.CompilerServices;


namespace FootballTeams.BL.Services
{
    internal class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IPlayerRepository _playerRepository;
        private readonly ILogger <TeamsService> _logger;

        public TeamsService (
            ITeamsRepository movieRepository,
            ILogger <TeamsService> logger,
            IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
            _logger = logger;
            _playerRepository = playerRepository;
        }
        public void Add(Teams team)
        {
            if ( team == null)
            {
                _logger.LogError("Team is null");
                return;
            }

            team.Id = Guid.NewGuid().ToString();
            _teamsRepository.Add(team);
        }
        public void AddPlayersToTeam(string teamId, string  playerId)
        {
            if (string.IsNullOrEmpty(teamId) || string.IsNullOrEmpty(playerId))
            {
                _logger.LogError("TeamId or Player is null");
                return;
            }
            if (Guid.TryParse(teamId, out _) || Guid.TryParse(playerId, out _))
            {
                _logger.LogError("TeamId or Player is not valid");
                return;
            }

            var team = _teamsRepository.GetById(teamId);

            if (team == null)
            {
                _logger.LogError("Team not found");
                return;
            }

            var player = _playerRepository.GetById(playerId);

            if (player == null)
            {
                _logger.LogError("Player not found");
                return;
            }

            if (team.Players == null)
            {
                team.Players = new List<string>();
            }

            team.Players.Add(playerId);

            _teamsRepository.Update(team);
        }

        public List<Teams> GetAll()
        {
            return _teamsRepository.GetAll();
        }

        public Teams? GetById(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out _)) return null;

            return _teamsRepository.GetById(id);
        }
    }
}
