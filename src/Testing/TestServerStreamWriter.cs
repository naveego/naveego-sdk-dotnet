using System.Threading.Tasks;
using Grpc.Core;
using Naveego.Sdk.Plugins;

namespace Naveego.Sdk.Testing
{
    public class TestServerRecordStreamWriter : IServerStreamWriter<Record>
    {
        public Task WriteAsync(Record message)
        {
            return Task.CompletedTask;
        }

        public WriteOptions WriteOptions { get; set; }
    }
}