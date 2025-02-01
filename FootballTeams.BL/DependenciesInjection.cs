using Microsoft.Extensions.DependencyInjection;
using FootballTeams.BL.Interfaces;
using FootballTeams.BL.Services;
using FootballTeams.DL;

namespace FootballTeams.Bl
{
    public static class DependenciesInjection
    {
        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
        {
            services.AddSingleton<ITeamService, TeamsService>();
            services.AddSingleton<IBusinessService, BusinessService>();
            services.AddSingleton<IPlayerService, PlayerService>();

            return services;
        }

        public static IServiceCollection RegisterDataLayer(this IServiceCollection services)
        {
            services.RegisterRepositories();
            return services;
        }
    }
}