using System.Threading.Tasks;

namespace AP.Constantine.Functions.Functions
{
    /// <summary>
    /// Avaliability check.
    /// </summary>
    public class HealthCheckFunction : FunctionBase
    {
        protected override string FunctionName => "HealthCheck";

        public override Task<object> InternalRun(string body, string requestId, string userId)
        {
            return Task.FromResult((object)"I AM ALIVE!");
        }
    }
}
