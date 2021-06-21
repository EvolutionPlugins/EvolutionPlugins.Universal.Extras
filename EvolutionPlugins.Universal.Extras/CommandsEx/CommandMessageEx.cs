using EvolutionPlugins.Universal.Extras.Messaging;
using Microsoft.Extensions.DependencyInjection;
using OpenMod.API.Users;
using OpenMod.Core.Commands;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.CommandsEx
{
    public abstract class CommandMessageEx : Command
    {
        private readonly IMessageManager m_MessageManager;

        public CommandMessageEx(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            m_MessageManager = serviceProvider.GetRequiredService<IMessageManager>();
        }

        public override Task PrintAsync(string message)
        {
            return m_MessageManager.PrintMessageAsync((IUser)Context.Actor, message);
        }

        public override Task PrintAsync(string message, Color color)
        {
            return m_MessageManager.PrintMessageAsync((IUser)Context.Actor, message, color);
        }
    }
}
