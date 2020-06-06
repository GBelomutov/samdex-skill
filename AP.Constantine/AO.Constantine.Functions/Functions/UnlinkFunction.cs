using System.Threading.Tasks;

namespace AP.Constantine.Functions.Functions
{
    public class UnlinkFunction : FunctionBase
    {
        protected override string FunctionName => "Unlink Devices";

        public override Task<object> InternalRun(string body, string requestId, string userId)
        {
            return Task.FromResult((object)"detatched");
        }
    }
}
