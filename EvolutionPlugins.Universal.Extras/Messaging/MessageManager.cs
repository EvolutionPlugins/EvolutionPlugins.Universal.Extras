using Autofac;
using Microsoft.Extensions.Logging;
using OpenMod.API;
using OpenMod.API.Users;
using OpenMod.Core.Ioc;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.Messaging
{
    public class MessageManager : IMessageManager
    {
        private readonly List<IMessageProvider> m_MessageProviders = new();

        public MessageManager(MessageManagerOptions options, ILifetimeScope lifetimeScope, IHostInformation hostInformation, ILogger<MessageManager> logger)
        {
            foreach (var messageProvider in options.BroadcastProviderTypes)
            {
                m_MessageProviders.Add((IMessageProvider)ActivatorUtilitiesEx.CreateInstance(lifetimeScope, messageProvider));
            }

            if (hostInformation.HostName.Contains("Unturned")
                && !m_MessageProviders.Any(x => x.GetType().Name.Contains("Unturned")))
            {
                logger.LogWarning("Install EvolutionPlugins.Universal.Extras.Unturned plugin for message supporting with iconUrl");
            }
        }

        public virtual async Task PrintMessageAsync(IUser user, string message)
        {
            foreach (var provider in m_MessageProviders)
            {
                await provider.PrintMessageAsync(user, message);
            }
        }

        public virtual async Task PrintMessageAsync(IUser user, string message, string? iconUrl)
        {
            foreach (var provider in m_MessageProviders)
            {
                await provider.PrintMessageAsync(user, message, iconUrl);
            }
        }

        public virtual async Task PrintMessageAsync(IUser user, string message, Color? color)
        {
            foreach (var provider in m_MessageProviders)
            {
                await provider.PrintMessageAsync(user, message, color);
            }
        }

        public virtual async Task PrintMessageAsync(IUser user, string message, string? iconUrl, Color? color)
        {
            foreach (var provider in m_MessageProviders)
            {
                await provider.PrintMessageAsync(user, message, iconUrl, color);
            }
        }
    }
}
