using System.Threading.Tasks;
using Grpc.Core;
using Aunalytics.Sdk.Plugins;

namespace Aunalytics.Sdk.Testing
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