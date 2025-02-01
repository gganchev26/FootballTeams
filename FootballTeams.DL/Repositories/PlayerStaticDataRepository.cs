using FootballTeams.DL.Interfaces;
using FootballTeams.DL.StaticData;
using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Repositories
{

    public class PlayerStaticDataRepository : IPlayerRepository
    {
        public List<Players> GetAll()
        {
            return StaticDb.PlayersData;
        }

        public Players? GetById(int id)
        {
            return StaticDb.PlayersData.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Players players)
        {
            StaticDb.PlayersData.Add(players);
        }

        public void Delete(int id)
        {
            var players = GetById(id);

            if (players != null)
            {
                StaticDb.PlayersData.Remove(players);
            }
        }
    }
}
