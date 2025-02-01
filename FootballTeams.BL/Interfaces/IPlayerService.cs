using FootballTeams.Models.DTO;

namespace FootballTeams.BL.Interfaces
{
    public interface IPlayerService
    {
        List<Players> GetAll();
        Players? GetById(int id);
        void Add(Players player);
        void Delete(int id);
    }
}