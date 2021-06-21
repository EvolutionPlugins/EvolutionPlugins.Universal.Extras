using EvolutionPlugins.Universal.Extras.Broadcast;
using EvolutionPlugins.Universal.Extras.Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EvolutionPlugins.Universal.Extras
{
    public static class ServiceCollectionExtension
    {
        public static void AddBroadcastManager(this IServiceCollection services)
        {
            services.Configure<BroadcastManagerOptions>(b =>
            {
                b.AddBroadcastProvider<DefaultBroadcastProvider>();
            });
            services.TryAddSingleton<IBroadcastManager, BroadcastManager>();
        }

        public static void AddMessageManager(this IServiceCollection services)
        {
            services.Configure<MessageManagerOptions>(b =>
            {
                b.AddMessageProvider<DefaultMessageProvider>();
            });
            services.TryAddSingleton<IMessageManager, MessageManager>();
        }
    }
}
