using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<Players>> GetAllAsync();
        Task<Players?> GetByIdAsync(int id);
        Task  AddAsync(Players player);
        Task  DeleteAsync(int id);
    }
}