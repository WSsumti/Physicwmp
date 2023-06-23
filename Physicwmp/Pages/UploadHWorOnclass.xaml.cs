using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Physicwmp.Pages.SmallPage.ForDocs;

namespace Physicwmp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UploadHWorOnclass : ContentPage
    {
        public UploadHWorOnclass()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 450,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            this.Navigation.PushModalAsync(new Show(layout,"Homeworks")
            {
                BackgroundColor = Color.White,
                Content = layout
            });
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 450,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            this.Navigation.PushModalAsync(new Show(layout, "Documents")
            {
                BackgroundColor = Color.White,
                Content = layout
            });
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new Add("Homework"));
        }

        private void Button_Clicked_3(object sender, EventArgs e)
        {
            this.Navigation.PushModalAsync(new Add("Document"));
        }
    }
}