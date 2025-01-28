using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Interfaces
{
    public interface IPlayerRepository
    {
        List<Players> GetAll();
        Players? GetById(string id);
    }
}
