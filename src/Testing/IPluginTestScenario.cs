using System.Threading;
using System.Threading.Tasks;

namespace Naveego.Sdk.Testing
{
    public interface IPluginTestScenario
    {
        Task RunAsync();
    }
}