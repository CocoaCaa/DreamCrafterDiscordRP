using System;
using System.Threading.Tasks;
using static DreamCrafterDiscordRP.Config;

namespace DreamCrafterDiscordRP
{
    public class DiscordBridge
    {
        public bool IsRunning { get; set; } = true;

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
                Console.WriteLine("Start Discord bridge");
                IsRunning = true;
                while (IsRunning)
                {
                    discord.RunCallbacks();
                    await Task.Delay(1000 / 60);
                }
            }
            finally
            {
                Console.WriteLine("Stop and dispose Discord bridge");
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
