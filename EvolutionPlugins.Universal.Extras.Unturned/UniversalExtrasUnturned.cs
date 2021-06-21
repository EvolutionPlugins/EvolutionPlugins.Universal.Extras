using OpenMod.API.Plugins;
using OpenMod.Unturned.Plugins;
using System;

[assembly: PluginMetadata("EvolutionPlugins.Universal.Extras.Unturned", Author = "EvolutionPlugins", DisplayName = "Universal Extras Unturned")]

namespace EvolutionPlugins.Universal.Extras.Unturned
{
    public class UniversalExtrasUnturned : OpenModUnturnedPlugin
    {
        public UniversalExtrasUnturned(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}
