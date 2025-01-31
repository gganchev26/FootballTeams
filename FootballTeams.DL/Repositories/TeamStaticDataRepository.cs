using FootballTeams.DL.Interfaces;
using FootballTeams.DL.StaticData;
using FootballTeams.Models.DTO;

namespace FootballTeams.DL.Repositories
{
    public class TeamStaticDataRepository  : ITeamsRepository
    {
       public List<Teams> GetTeamByPlacement(int placement)
        {
            return StaticDb.TeamsData.Where(x => x.Placement == placement).ToList();
        }
    }
}
