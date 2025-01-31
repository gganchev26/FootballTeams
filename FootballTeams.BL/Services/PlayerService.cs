using Microsoft.Extensions.Logging;
using FootballTeams.BL.Interfaces;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;

namespace FootballTeams.BL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ILogger<PlayerService> _logger;

        public PlayerService(
            IPlayerRepository playerRepository, ILogger<PlayerService> logger)
        {
            _playerRepository = playerRepository;
            _logger = logger;
        }

        public void Add(Players player)
        {
            if (player == null)
            {
                _logger.LogError("Player is null");
                return;
            }
            _playerRepository.Add(player);
        }

        public void Delete(int id)
        {
            _playerRepository.Delete(id);
        }

        public List<Players> GetAll()
        {
            return _playerRepository.GetAll();
        }

        public Players? GetById(int id)
        {           
            return _playerRepository.GetById(id);
        }
    }
}
