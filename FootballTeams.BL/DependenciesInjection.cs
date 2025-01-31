using Microsoft.Extensions.DependencyInjection;
using FootballTeams.BL.Interfaces;
using FootballTeams.BL.Services;
using FootballTeams.DL;

namespace FootballTeams.BL
{
    public static class DependenciesInjection
    {
        public static IServiceCollection
            RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<ITeamService, TeamsService>();
            services.AddSingleton<IPlayerService, PlayerService>();
            services.AddSingleton<BusinessService, BusinessService>();

            return services;
        }       
    }
}