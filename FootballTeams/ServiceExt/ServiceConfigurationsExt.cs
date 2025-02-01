using FootballTeams.BL.Interfaces;
using FootballTeams.DL.Interfaces;
using FootballTeams.Models.Configurations;
using FootballTeams.BL.Services;
using FootballTeams.DL.Repositories.MongoDb;

namespace FootballTeams.ServiceExt
{
    public static class ServiceConfigurationsExt
    {
        public static IServiceCollection AddConfigurations(
            this IServiceCollection services,
            IConfiguration configuration) 
        {
            return services.Configure<MongoDbConfiguration>(
                configuration.GetSection(nameof(MongoDbConfiguration)));
        }
        public static IServiceCollection RegisterDataLayer(this IServiceCollection services)
        {
            services.AddScoped<ITeamsRepository, TeamRepository>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            return services;
        }

        public static IServiceCollection RegisterBusinessLayer(this IServiceCollection services)
        {
            services.AddScoped<ITeamService, TeamsService>();
            services.AddScoped<IBusinessService, BusinessService>();
            services.AddScoped<IPlayerService, PlayerService>();
            return services;
        }
    }
}
