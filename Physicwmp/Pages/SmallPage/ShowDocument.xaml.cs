using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physicwmp.Pages.SmallPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowDocument : ContentPage
    {
        public ShowDocument(StackLayout layout, string url)
        {
            InitializeComponent();
            UI(layout, new Uri(url));
        }
        public void UI(StackLayout layout, Uri url)
        {
            Button back = new Button()
            {
                Text = "Back",
                FontSize = 12,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            back.Clicked += Back_Clicked;
            layout.Children.Add(back);
            WebView view = new WebView()
            {
                Source = url,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };
            layout.Children.Add(view);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}