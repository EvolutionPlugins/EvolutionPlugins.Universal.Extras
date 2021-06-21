using OpenMod.API.Users;
using System.Drawing;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.Broadcast
{
    public class DefaultBroadcastProvider : IBroadcastProvider
    {
        private readonly IUserManager m_UserManager;

        public DefaultBroadcastProvider(IUserManager userManager)
        {
            m_UserManager = userManager;
        }

        public Task BroadcastAsync(string message)
        {
            return m_UserManager.BroadcastAsync(message);
        }

        public Task BroadcastAsync(string message, string? iconUrl)
        {
            return m_UserManager.BroadcastAsync(message);
        }

        public Task BroadcastAsync(string message, Color? color)
        {
            return m_UserManager.BroadcastAsync(message, color);
        }

        public Task BroadcastAsync(string message, string? iconUrl, Color? color)
        {
            return m_UserManager.BroadcastAsync(message, color);
        }
    }
}
