using FootballTeams.Bl;

namespace FootballTeams
{
    public static class DependenciesInjection
    {
        public static void RegisterService(this IServiceCollection services)
        {
           // services.RegisterDataLayer();
            services.RegisterBusinessLayer();
        }
    }
}
