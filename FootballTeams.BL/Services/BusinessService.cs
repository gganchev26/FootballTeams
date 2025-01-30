using FootballTeams.BL.Interfaces;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Responses;

namespace FootballTeams.BL.Services
{
    public class BusinessService : IBusinessService
    {
        private readonly ITeamsRepository _teamsRepository;
        private readonly IPlayerRepository _playerRepository;
    

        public BusinessService(
           ITeamsRepository teamsRepository,
           IPlayerRepository playerRepository)
        {
            _teamsRepository = teamsRepository;
            _playerRepository = playerRepository;
        }

        public List<TeamsFullDetailsResponse> GetAllTeams()
        {
            var result = new List<TeamsFullDetailsResponse>();

            var teams = _teamsRepository.GetAll();

            foreach ( var team in teams )
            {
                var detailedTeam = new TeamsFullDetailsResponse()
                {
                    Id = team.Id,
                    Name = team.Name,
                    Ranking = team.Ranking
                };

                foreach ( var playerId in team.Players ) { 
                    var player = _playerRepository.GetById( playerId );
                    if (player == null) continue;
                    detailedTeam.Players.Add( player );
                }
                result.Add( detailedTeam );
            }
            return result;
        }
    }
}

