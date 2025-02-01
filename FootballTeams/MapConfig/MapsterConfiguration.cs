using Mapster;
using FootballTeams.Models.DTO;
using FootballTeams.Models.Request;

namespace FootballTeam.MapConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        { 
            TypeAdapterConfig<Teams, AddTeamRequest>
                .NewConfig()
                .TwoWays();
        }
    }
}