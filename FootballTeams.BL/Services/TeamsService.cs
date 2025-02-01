using FootballTeams.BL.Interfaces;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.DTO;

namespace FootballTeams.BL.Services
{
    public class TeamsService : ITeamService
    {
        private readonly ITeamsRepository _teamsrepository;
        private readonly IPlayerRepository _playerrepository;

        public TeamsService(ITeamsRepository teamsRepository) 
        { 
            _teamsrepository = teamsRepository;
        }

        public List<Teams> GetAllTeamsFromPlayers(int playerId)
        {
            return _teamsrepository.GetAllTeamsFromPlayers(playerId);
        }
    }
}
