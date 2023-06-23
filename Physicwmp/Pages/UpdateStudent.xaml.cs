using Physicwmp.Data;
using Physicwmp.Pages.SmallPage.ForStudent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physicwmp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateStudent : ContentPage
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private void Im1_Clicked(object sender, EventArgs e)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 550,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            this.Navigation.PushModalAsync(new Add(layout)
            {
                BackgroundColor = Color.White,
                Content = layout
            });
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 450,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            this.Navigation.PushModalAsync(new Update(layout, 12)
            {
                BackgroundColor = Color.White,
                Content = layout
            });
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 450,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            this.Navigation.PushModalAsync(new Update(layout, 11)
            {
                BackgroundColor = Color.White,
                Content = layout
            });
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
            this.Navigation.PushModalAsync(new Update(layout, 10)
            {
                BackgroundColor = Color.White,
                Content = layout
            });
        }
    }
}