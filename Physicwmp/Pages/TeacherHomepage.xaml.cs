using Newtonsoft.Json;
using Physicwmp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Physicwmp.Pages.SmallPage;

namespace Physicwmp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeacherHomepage : ContentPage
    {
        public TeacherHomepage()
        {
            InitializeComponent();
            
            
        }

        private void Button_Clicked1(object sender, EventArgs e)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 450,
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
            this.Navigation.PushModalAsync(new Noti(layout, 12)
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
            this.Navigation.PushModalAsync(new Noti(layout, 11)
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
            this.Navigation.PushModalAsync(new Noti(layout, 10)
            {
                BackgroundColor = Color.White,
                Content = layout
            });
        }
    }
}