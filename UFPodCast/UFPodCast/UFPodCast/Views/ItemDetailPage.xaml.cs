
using Plugin.MediaManager;
using Plugin.MediaManager.Abstractions;
using Plugin.MediaManager.Abstractions.Enums;
using Plugin.MediaManager.Abstractions.Implementations;
using Plugin.Share;
using UFPodCast.ViewModels;
using Xamarin.Forms;

namespace UFPodCast.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
  

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

            //BindingContext = item;
            CrossMediaManager.Current.PlayingChanged += (sender, args) => ProgressBar.Progress = args.Progress;
            CrossMediaManager.Current.Play(new MediaFile("", MediaFileType.Audio));
            webView.Source = new HtmlWebViewSource
            {
                Html = "asfsdasdfsa"// item.Description
            };


            var share = new ToolbarItem
            {
                Icon = "ic_share.png",
                Text = "Share",
                Command = new Command(() =>
                {
                    CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage
                    {
                        Text = "Listening to @sUFPodCast's ",// + item.Title + " " + item.Link,
                        Title = "Share",
                        Url = ""//item.Link
                    });
                })
            };

            ToolbarItems.Add(share);

            play.Clicked += (sender, args) => PlaybackController.Play();
            pause.Clicked += (sender, args) => PlaybackController.Pause();
            stop.Clicked += (sender, args) => PlaybackController.Stop();

            if (Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.WinPhone)
            {
                play.Text = "Play";
                pause.Text = "Pause";
                stop.Text = "Stop";
            }

            if ((Device.OS == TargetPlatform.WinPhone || Device.OS == TargetPlatform.Windows))
            {
                this.BackgroundColor = Color.White;
                this.title.TextColor = Color.Black;
                this.date.TextColor = Color.Black;
                this.play.TextColor = Color.Black;
                this.pause.TextColor = Color.Black;
                this.stop.TextColor = Color.Black;
            }
        }

        private IPlaybackController PlaybackController => CrossMediaManager.Current.PlaybackController;
      


    }
}
