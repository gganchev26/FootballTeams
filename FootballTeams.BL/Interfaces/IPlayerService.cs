using FootballTeams.Models.DTO;

namespace FootballTeams.BL.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Players>> GetAllAsync();
        Task<Players?> GetByIdAsync(int id);
        Task AddAsync(Players player);
        Task DeleteAsync(int id);
    }
}