using System;
using System.Threading.Tasks;
using static DreamCrafterDiscordRP.Config;

namespace DreamCrafterDiscordRP
{
    public class DiscordBridge
    {
        private Discord.Discord discord;

        public DiscordBridge Start(long clinetId)
        {
            discord = new Discord.Discord(clinetId, (UInt64)Discord.CreateFlags.Default);
            SetActivity(new DisplayItem()
            {
                State = "閒置中 []~(￣▽￣)~*"
            });
            Task.Run(StartInstance);
            return this;
        }

        private async Task StartInstance()
        {
            try
            {
                while (true)
                {
                    discord.RunCallbacks();
                    await Task.Delay(1000 / 60);
                }
            }
            finally
            {
                discord.Dispose();
            }
        }

        public void SetActivity(DisplayItem displayItem, bool withStartTime = false)
        {
            var activity = new Discord.Activity
            {
                State = displayItem.State,
                Details = displayItem.Details,
                Assets = {
                    LargeImage = displayItem.ImageKey,
                    LargeText = displayItem.Details,
                },
                Instance = true,
            };

            if (withStartTime)
            {
                activity.Timestamps = new Discord.ActivityTimestamps {
                    Start = DateTimeOffset.UtcNow.ToUnixTimeSeconds(),
                };
            }

            discord.GetActivityManager().UpdateActivity(activity, (result) => Console.WriteLine(result));
        }
    }
}
