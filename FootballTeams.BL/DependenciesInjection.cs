using Microsoft.Extensions.DependencyInjection;
using FootballTeams.BL.Interfaces;
using FootballTeams.BL.Services;

namespace FootballTeams.BL
{
    public static class DependenciesInjection
    {
        public static IServiceCollection
            RegisterServices(this IServiceCollection services)
        {
            return services
                        .AddSingleton<ITeamsService, TeamsService>()
                        .AddSingleton<IBusinessService, BusinessService>();
        }
    }
}