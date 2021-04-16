using System;
using System.Threading.Tasks;
using Naveego.Sdk.Testing;

namespace Naveego.Sdk.TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var scenario = new PluginTestScenarioBuilder<DummyPublisher>()
                .Configure(config =>
                {

                })
                .Read(configRead =>
                {
                    configRead.JobId = "";
                });

            await scenario.RunAsync();
        }
    }
}