using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Core.Testing;
using Pub;

namespace Naveego.Sdk.Testing
{
    public class RunReadJobScenario : IPluginTestScenario
    {
        private readonly ConfigureRequest _configureRequest;
        private readonly ReadRequest _readRequest;
        private readonly Publisher.PublisherBase _publisher;

        public RunReadJobScenario(Publisher.PublisherBase publisher, 
            ConfigureRequest configureRequest, ReadRequest readRequest)
        {
            _publisher = publisher;
            _configureRequest = configureRequest;
            _readRequest = readRequest;
        }
        
        public async Task RunAsync()
        {
            var callContext = TestServerCallContext.Create(
                "",
                "",
                DateTime.MaxValue,
                new Metadata(),
                CancellationToken.None,
                "",
                new AuthContext("", new Dictionary<string, List<AuthProperty>>()),
                null,
                (m) => Task.CompletedTask,
                () => WriteOptions.Default,
                (wo) => { });
            
            await _publisher.Configure(_configureRequest, callContext);
            await _publisher.ReadStream(_readRequest, new TestServerRecordStreamWriter(), callContext);
        }
    }
}