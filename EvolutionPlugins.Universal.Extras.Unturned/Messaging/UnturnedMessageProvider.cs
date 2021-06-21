using Cysharp.Threading.Tasks;
using EvolutionPlugins.Universal.Extras.Messaging;
using OpenMod.API.Users;
using OpenMod.UnityEngine.Extensions;
using OpenMod.Unturned.Users;
using SDG.Unturned;
using System.Drawing;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.Unturned.Messaging
{
    public class UnturnedMessageProvider : DefaultMessageProvider
    {
        public new Task PrintMessageAsync(IUser user, string message)
        {
            return PrintMessageAsync(user, message, null, null);
        }

        public new Task PrintMessageAsync(IUser user, string message, string? iconUrl)
        {
            return PrintMessageAsync(user, message, iconUrl, null);
        }

        public new Task PrintMessageAsync(IUser user, string message, Color? color)
        {
            return PrintMessageAsync(user, message, null, color);
        }

        public new Task PrintMessageAsync(IUser user, string message, string? iconUrl, Color? color)
        {
            if (user is not UnturnedUser unturnedUser)
            {
                return base.PrintMessageAsync(user, message, iconUrl, color);
            }

            async UniTask PrintMessage()
            {
                await UniTask.SwitchToMainThread();
                ChatManager.serverSendMessage(message, (color ?? Color.White).ToUnityColor(), toPlayer: unturnedUser.Player.SteamPlayer,
                    iconURL: iconUrl, useRichTextFormatting: true);
            }

            return PrintMessage().AsTask();
        }
    }
}
