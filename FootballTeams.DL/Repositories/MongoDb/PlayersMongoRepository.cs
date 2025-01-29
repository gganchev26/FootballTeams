using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Repositories.MongoDb
{
    internal class PlayersMongoRepository : IPlayerRepository
    {
        public List<Players> GetAll()
        {
            throw new NotImplementedException();
        }

        public Players? GetById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
