using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace DreamCrafterDiscordRP
{
    public class DisplayItemControl : UserControl
    {
        private Config.DisplayItem displayItem;

        public event EventHandler<RoutedEventArgs> OnClick;

        public TextBlock ActivedText { get; set; }

        public bool IsActive
        {
            get
            {
                return ActivedText.IsVisible;
            }

            set
            {
                ActivedText.IsVisible = value;
            }
        }

        public DisplayItemControl(Config.DisplayItem displayItem)
        {
            this.displayItem = displayItem;

            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);

            var uri = new Uri($"avares://DreamCrafterDiscordRP/Assets/{displayItem.ButtonIconSrc}", UriKind.RelativeOrAbsolute);
            var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
            this.FindControl<Image>("SelectIcon").Source = new Bitmap(assets.Open(uri));

            ActivedText = this.FindControl<TextBlock>("ActivedText");
        }

        private void HandleClick(object sender, RoutedEventArgs e)
        {
            if (OnClick == null)
            {
                return;
            }

            OnClick(sender, e);
        }
    }
}
