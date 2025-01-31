using Microsoft.Extensions.DependencyInjection;
using FootballTeams.DL.Interfaces;
using FootballTeams.DL.Repositories;
using FootballTeams.DL.Repositories.MongoDb;

namespace FootballTeams.DL
{
    public static class DependenciesInjection
    {
        public static IServiceCollection 
            RegisterRepositoies(this IServiceCollection services)
        {
            return services
                .AddSingleton<ITeamsRepository, TeamMongoRepository>()
                .AddSingleton<IPlayerRepository, PlayerMongoRepository>();
            
        }
    }
}
