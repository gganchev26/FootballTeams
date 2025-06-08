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

        public async Task AddAsync(Players player)
        {
            await _playerRepository.AddAsync(player);
        }

        public async Task DeleteAsync(int id)
        {
            await _playerRepository.DeleteAsync(id);
        }

        public async Task<List<Players>> GetAllAsync()
        {
            return await _playerRepository.GetAllAsync();
        }

        public async Task<Players?> GetByIdAsync(int id)
        {
            return await _playerRepository.GetByIdAsync(id);
        }
    }
}
