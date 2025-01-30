using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace FootballTeams.HealthChecks
{
    public class CustomHealthChecks : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsyns(
            HealthCheckContext context,
            CancellationToken cancellationToken = default)
        {
            var isHealthy = true;

            if (isHealthy)
            {
                return Task.FromResult(HealthCheckResult.Healthy("A healthy result."));
            }

            return Task.FromResult( new HealthCheckResult(context.Registration.FailureStatus, "An unhealthy result."));
        }
    }
}
