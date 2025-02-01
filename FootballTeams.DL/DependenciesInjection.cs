using Microsoft.Extensions.DependencyInjection;
using FootballTeams.DL.Interfaces;
using FootballTeams.DL.Repositories.MongoDb;
using FootballTeams.DL.Repositories;

namespace FootballTeams.DL
{
    public static class DependenciesInjection
    {
        public static IServiceCollection
            RegisterRepositories(this IServiceCollection services)
        {
            return
                services
                .AddSingleton<ITeamsRepository, TeamRepository>()
                .AddSingleton<IPlayerRepository, PlayerRepository>();
        }
    }
}