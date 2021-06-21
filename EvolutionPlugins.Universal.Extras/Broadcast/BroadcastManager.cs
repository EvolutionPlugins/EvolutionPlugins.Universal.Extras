using Autofac;
using Microsoft.Extensions.Logging;
using OpenMod.API;
using OpenMod.Core.Helpers;
using OpenMod.Core.Ioc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.Broadcast
{
    public class BroadcastManager : IBroadcastManager, IAsyncDisposable
    {
        private readonly List<IBroadcastProvider> m_BroadcastProviders = new();

        public BroadcastManager(BroadcastManagerOptions options, ILifetimeScope lifetimeScope, IHostInformation hostInformation,
            ILogger<BroadcastManager> logger)
        {
            foreach (var provider in options.BroadcastProviderTypes)
            {
                m_BroadcastProviders.Add((IBroadcastProvider)ActivatorUtilitiesEx.CreateInstance(lifetimeScope, provider));
            }

            if (hostInformation.HostName.Contains("Unturned")
                && !m_BroadcastProviders.Any(x => x.GetType().Name.Contains("Unturned")))
            {
                logger.LogWarning("Install EvolutionPlugins.Universal.Extras.Unturned plugin for broadcast supporting with iconUrl");
            }
        }

        public virtual async Task BroadcastAsync(string message)
        {
            foreach (var broadcastProvider in m_BroadcastProviders)
            {
                await broadcastProvider.BroadcastAsync(message);
            }
        }

        public virtual async Task BroadcastAsync(string message, string? iconUrl)
        {
            foreach (var broadcastProvider in m_BroadcastProviders)
            {
                await broadcastProvider.BroadcastAsync(message, iconUrl);
            }
        }

        public virtual async Task BroadcastAsync(string message, Color? color)
        {
            foreach (var broadcastProvider in m_BroadcastProviders)
            {
                await broadcastProvider.BroadcastAsync(message, color);
            }
        }

        public virtual async Task BroadcastAsync(string message, string? iconUrl, Color? color)
        {
            foreach (var broadcastProvider in m_BroadcastProviders)
            {
                await broadcastProvider.BroadcastAsync(message, iconUrl, color);
            }
        }

        public virtual async ValueTask DisposeAsync()
        {
            foreach (var broadcastProvider in m_BroadcastProviders)
            {
                await broadcastProvider.DisposeSyncOrAsync();
            }
        }
    }
}
