using OpenMod.API.Users;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.Messaging
{
    public interface IMessageProvider
    {
        Task PrintMessageAsync(IUser user, string message);

        Task PrintMessageAsync(IUser user, string message, string? iconUrl);

        Task PrintMessageAsync(IUser user, string message, Color? color);

        Task PrintMessageAsync(IUser user, string message, string? iconUrl, Color? color);
    }
}
