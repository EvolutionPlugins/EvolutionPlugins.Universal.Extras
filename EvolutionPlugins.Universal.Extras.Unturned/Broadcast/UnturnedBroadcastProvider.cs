using Cysharp.Threading.Tasks;
using EvolutionPlugins.Universal.Extras.Broadcast;
using OpenMod.UnityEngine.Extensions;
using SDG.Unturned;
using System;
using System.Drawing;
using System.Threading.Tasks;

namespace EvolutionPlugins.Universal.Extras.Unturned.Broadcast
{
    public class UnturnedBroadcastProvider : IBroadcastProvider
    {
        public Task BroadcastAsync(string message)
        {
            return BroadcastAsync(message, null, null);
        }

        public Task BroadcastAsync(string message, string? iconUrl)
        {
            return BroadcastAsync(message, iconUrl, null);
        }

        public Task BroadcastAsync(string message, Color? color)
        {
            return BroadcastAsync(message, null, color);
        }

        public Task BroadcastAsync(string message, string? iconUrl, Color? color)
        {
            if (string.IsNullOrEmpty(message))
            {
                return Task.FromException(new ArgumentException($"'{nameof(message)}' cannot be null or empty.", nameof(message)));
            }

            async UniTask Broadcast()
            {
                await UniTask.SwitchToMainThread();
                ChatManager.serverSendMessage(message, (color ?? Color.White).ToUnityColor(), mode: EChatMode.GLOBAL,
                    iconURL: iconUrl, useRichTextFormatting: true);
            }

            return Broadcast().AsTask();
        }
    }
}
