using FootballTeams.DL.Interfaces;
using FootballTeams.DL.StaticData;
using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Repositories
{
    internal class TeamStaticDataRepository  : ITeamsRepository
    {
        public void Add(Teams team)
        {
            throw new NotImplementedException();
        }

        public List<Teams> GetAll()
        {
            return StaticDb.Teams;
        }
        public Teams? GetById(string id)
        {
            if (string.IsNullOrEmpty(id)) return null;

            return StaticDb.Teams.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Teams team)
        {
            throw new NotImplementedException();
        }
    }
}
