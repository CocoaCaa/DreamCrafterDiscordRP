using System;
using System.Collections.Generic;
using System.Text;

namespace DreamCrafterDiscordRP
{
    public class Config
    {
        public long DiscordClientId { get; } = 638385568274710530;

        public DisplayItem[] displayItems = new[] {
            new DisplayItem {
                ButtonIconSrc = "select-icons-survive.png",
                State = "( •̀ ω •́ )y",
                Details = "原味生存",
                ImageKey = "status-icons-survive"
            },
            new DisplayItem {
                ButtonIconSrc = "select-icons-skyblock.png",
                State = "(◕ܫ◕)",
                Details = "休閒空島",
                ImageKey = "status-icons-skyblock"
            },
            new DisplayItem {
                ButtonIconSrc = "select-icons-creative.png",
                State = "(∩^o^)⊃━☆ﾟ.*･｡ 🏬",
                Details = "木斧建築",
                ImageKey = "status-icons-creative"
            },
        };

        public class DisplayItem
        {
            public string ButtonIconSrc { get; set; }
            public string State { get; set; }
            public string Details { get; set; }
            public string ImageKey { get; set; }
        }
    }
}
