﻿using System;
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
            new DisplayItem {
                ButtonIconSrc = "select-icons-cny-2020-riddle.png",
                State = "2020新春 (っ´ω`c)",
                Details = "新春猜謎大賽 2020",
                ImageKey = "status-icons-cny-2020-riddle"
            },
            new DisplayItem {
                ButtonIconSrc = "select-icons-cny-2020.png",
                State = "2020新春 ( />ω<)/♪",
                Details = "新春合成大賽 2020",
                ImageKey = "status-icons-cny-2020"
            },
            new DisplayItem {
                ButtonIconSrc = "select-icons-christmas-2019.png",
                State = "聖誕節 ✧◝(⁰▿⁰)◜✧",
                Details = "聖誕節活動 2019",
                ImageKey = "status-icons-christmas-2019"
            },
            new DisplayItem {
                ButtonIconSrc = "select-icons-3rd-anniversary.png",
                State = "三歲歲 o(〃'▿'〃)o",
                Details = "三週年活動",
                ImageKey = "status-icons-3rd-anniversary"
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
