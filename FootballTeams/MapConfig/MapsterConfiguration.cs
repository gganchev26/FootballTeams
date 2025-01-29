using Mapster;
using FootballTeams.Models.DTO;
using FootballTeams.Models.Requests;


namespace FootballTeams.MapConfig
{
    public class MapsterConfiguration
    {
        public static void Configure()
        {
            TypeAdapterConfig<AddTeamRequest, Teams>
                .NewConfig();
        }
    }
}
