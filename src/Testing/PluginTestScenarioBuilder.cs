using System;
using Pub;

namespace Naveego.Sdk.Testing
{
    public class PluginTestScenarioBuilder<T>
        where T : Publisher.PublisherBase, new()
    {

        private readonly Publisher.PublisherBase _publisher;
        private ConfigureRequest _configureRequest;

        public PluginTestScenarioBuilder()
        {
            _publisher = new T();
        }
        
        public PluginTestScenarioBuilder<T> Configure(Action<ConfigureRequest> config)
        {
            _configureRequest = new ConfigureRequest();
            config(_configureRequest);
            return this;
        }

        public IPluginTestScenario Read(Action<ReadRequest> configureRead)
        {
            var readRequest = new ReadRequest();
            configureRead(readRequest);
            return new RunReadJobScenario(_publisher, _configureRequest, readRequest);
        }
    }
}