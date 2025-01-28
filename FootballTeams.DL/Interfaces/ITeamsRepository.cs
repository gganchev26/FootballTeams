using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Interfaces
{
    public interface ITeamsRepository
    {
        List<Teams> GetAll();
        Teams? GetById(string id);
        void Add(Teams team);
        void Update(Teams team);
    }
}
