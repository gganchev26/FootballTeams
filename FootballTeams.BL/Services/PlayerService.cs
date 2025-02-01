using FootballTeams.BL.Interfaces;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;

namespace FootballTeams.BL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public void Add(Players player)
        {
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
