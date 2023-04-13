using System.Threading.Tasks;

namespace Aunalytics.Sdk.Testing
{
    public interface IPluginTestScenario
    {
        Task RunAsync();
    }
}