using OpenMod.API.Users;
using System.Drawing;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.Messaging
{
    public class DefaultMessageProvider : IMessageProvider
    {
        public Task PrintMessageAsync(IUser user, string message)
        {
            return user.PrintMessageAsync(message);
        }

        public Task PrintMessageAsync(IUser user, string message, string? iconUrl)
        {
            return user.PrintMessageAsync(message);
        }

        public Task PrintMessageAsync(IUser user, string message, Color? color)
        {
            return user.PrintMessageAsync(message, color ?? Color.White);
        }

        public Task PrintMessageAsync(IUser user, string message, string? iconUrl, Color? color)
        {
            return user.PrintMessageAsync(message, color ?? Color.White);
        }
    }
}