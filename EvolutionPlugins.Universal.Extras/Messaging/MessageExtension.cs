using Autofac;
using OpenMod.API.Commands;
using OpenMod.API.Users;
using OpenMod.Core.Commands;
using System.Drawing;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.Messaging
{
    public static class MessageExtension
    {
        public static Task PrintMessageAsync(this IUser user, ILifetimeScope lifetimeScope, string message, string? iconUrl = null, Color? color = null)
        {
            var messageManager = lifetimeScope.Resolve<IMessageManager>();
            return messageManager.PrintMessageAsync(user, message, iconUrl, color);
        }

        public static Task PrintMessage(this CommandBase command, ILifetimeScope lifetimeScope, string message, string? iconUrl = null, Color? color = null)
        {
            var messageManager = lifetimeScope.Resolve<IMessageManager>();
            return messageManager.PrintMessageAsync((IUser)command.Context.Actor, message, iconUrl, color);
        }
    }
}
