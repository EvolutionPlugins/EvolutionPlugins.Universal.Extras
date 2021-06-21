using System.Drawing;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.Broadcast
{
    public interface IBroadcastManager
    {
        Task BroadcastAsync(string message);

        Task BroadcastAsync(string message, string? iconUrl);

        Task BroadcastAsync(string message, Color? color);

        Task BroadcastAsync(string message, string? iconUrl, Color? color);
    }
}
