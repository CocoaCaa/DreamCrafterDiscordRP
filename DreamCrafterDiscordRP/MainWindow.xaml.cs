﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

using System;
using System.Linq;
using System.Collections.Generic;

namespace DreamCrafterDiscordRP
{
    public class MainWindow : Window
    {
        private WrapPanel DisplayItemsContainer { get; set; }

        private Config config;
        private DiscordBridge discordBridge;

        private List<DisplayItemControl> displayItemControls;

        public MainWindow(Config config, DiscordBridge discordBridge)
        {
            this.config = config;
            this.discordBridge = discordBridge;

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            DisplayItemsContainer = this.FindControl<WrapPanel>("DisplayItemsContainer");

            displayItemControls = config.displayItems
                .Select((displayItem, idx) =>
                {
                    var displayItemControl = new DisplayItemControl(displayItem);
                    displayItemControl.OnClick += (sender, e) => HandleDisplayItemClick(idx);
                    return displayItemControl;
                })
                .ToList();

            foreach (var displayItemControl in displayItemControls)
            {
                DisplayItemsContainer.Children.Add(displayItemControl);
            }
        }

        private void HandleDisplayItemClick(int idx)
        {
            var displayItem = config.displayItems[idx];
            var displayItemControl = displayItemControls[idx];

            discordBridge.SetActivity(displayItem, true);

            displayItemControls.ForEach(d => d.IsActive = false);
            displayItemControl.IsActive = true;
        }
    }
}
