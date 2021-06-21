using OpenMod.Core.Prioritization;
using System;
using System.Collections.Generic;

namespace EvolutionPlugins.Universal.Extras.Broadcast
{
    public class BroadcastManagerOptions
    {
        private readonly List<Type> m_BroadcastProviderTypes;
        private readonly PriorityComparer m_PriorityComparer;
        public IReadOnlyCollection<Type> BroadcastProviderTypes => m_BroadcastProviderTypes;

        public BroadcastManagerOptions()
        {
            m_PriorityComparer = new(PriortyComparisonMode.HighestFirst);
            m_BroadcastProviderTypes = new();
        }

        public void AddBroadcastProvider<TProvider>() where TProvider : IBroadcastProvider
        {
            var type = typeof(TProvider);

            if (m_BroadcastProviderTypes.Contains(type))
            {
                return;
            }

            m_BroadcastProviderTypes.Add(type);
            m_BroadcastProviderTypes.Sort((a, b) => m_PriorityComparer.Compare(a.GetPriority(), b.GetPriority()));
        }

        public void RemoveBroadcastProvider<TProvider>() where TProvider : IBroadcastProvider
        {
            m_BroadcastProviderTypes.RemoveAll(x => x == typeof(TProvider));
        }
    }
}
