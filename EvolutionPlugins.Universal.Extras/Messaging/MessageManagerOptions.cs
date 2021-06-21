using OpenMod.Core.Prioritization;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvolutionPlugins.Universal.Extras.Messaging
{
    public class MessageManagerOptions
    {
        private readonly List<Type> m_MessageProviderTypes;
        private readonly PriorityComparer m_PriorityComparer;
        public IReadOnlyCollection<Type> BroadcastProviderTypes => m_MessageProviderTypes;

        public MessageManagerOptions()
        {
            m_PriorityComparer = new(PriortyComparisonMode.HighestFirst);
            m_MessageProviderTypes = new();
        }

        public void AddMessageProvider<TProvider>() where TProvider : IMessageProvider
        {
            var type = typeof(TProvider);

            if (m_MessageProviderTypes.Contains(type))
            {
                return;
            }

            m_MessageProviderTypes.Add(type);
            m_MessageProviderTypes.Sort((a, b) => m_PriorityComparer.Compare(a.GetPriority(), b.GetPriority()));
        }

        public void RemoveMessageProvider<TProvider>() where TProvider : IMessageProvider
        {
            m_MessageProviderTypes.RemoveAll(x => x == typeof(TProvider));
        }
    }
}
