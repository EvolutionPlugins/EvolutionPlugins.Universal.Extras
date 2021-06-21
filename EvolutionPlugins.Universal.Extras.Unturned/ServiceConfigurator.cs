using EvolutionPlugins.Universal.Extras.Broadcast;
using EvolutionPlugins.Universal.Extras.Messaging;
using EvolutionPlugins.Universal.Extras.Unturned.Broadcast;
using EvolutionPlugins.Universal.Extras.Unturned.Messaging;
using Microsoft.Extensions.DependencyInjection;
using OpenMod.API.Ioc;
using OpenMod.API.Plugins;
using System;

namespace EvolutionPlugins.Universal.Extras.Unturned
{
    public class ServiceConfigurator : IServiceConfigurator
    {
        public void ConfigureServices(IOpenModServiceConfigurationContext openModStartupContext, IServiceCollection serviceCollection)
        {
            serviceCollection.Configure<BroadcastManagerOptions>(b =>
            {
                b.RemoveBroadcastProvider<DefaultBroadcastProvider>();
                b.AddBroadcastProvider<UnturnedBroadcastProvider>();
            });

            serviceCollection.Configure<MessageManagerOptions>(b =>
            {
                b.RemoveMessageProvider<DefaultMessageProvider>();
                b.AddMessageProvider<UnturnedMessageProvider>();
            });
        }
    }
}
