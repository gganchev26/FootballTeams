using FootballTeams.DL.Interfaces;
using FootballTeams.DL.StaticData;
using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Repositories
{
    [Obsolete]
    internal class PlayerStaticDataRepository : IPlayerRepository
    {
        public List<Players> GetAll()
        {
            return StaticDb.Players;
        }

        public Players? GetById(string id) {
            if (string.IsNullOrEmpty(id))
                return null;

            return StaticDb.Players.FirstOrDefault(x => x.Id == id);
        }
    }
}
