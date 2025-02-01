using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Interfaces
{
    public interface IPlayerRepository
    {
        List<Players> GetAll();
        Players? GetById(int id);
        void Add (Players player);
        void Delete(int id);
    }
}