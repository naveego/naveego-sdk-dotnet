using System.Threading.Tasks;
using Grpc.Core;
using Pub;

namespace Naveego.Sdk.TestConsole
{
    public class DummyPublisher : Publisher.PublisherBase
    {
        public override Task<ConfigureResponse> Configure(ConfigureRequest request, ServerCallContext context)
        {
            return Task.FromResult(new ConfigureResponse());
        }

        public override Task ReadStream(ReadRequest request, IServerStreamWriter<Record> responseStream, ServerCallContext context)
        {
            return Task.CompletedTask;
        }
    }
}