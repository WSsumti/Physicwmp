using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Physicwmp.Data;
using Physicwmp.Pages.SmallPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physicwmp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Info : ContentPage
    {
        public Info()
        {
            InitializeComponent();
            StackLayout layout = new StackLayout();
            if (App.student.isMale)
            {
                var img = new Image()
                {
                    Source = "boy.jpg",
                    HeightRequest = 100,
                    WidthRequest = 100
                };
                layout.Children.Add(img);
            }
            else
            {
                var img = new Image()
                {
                    Source = "girl.png",
                    HeightRequest = 100,
                    WidthRequest = 100
                };
                layout.Children.Add(img);
            };


            var lb = new Label
            {
                Text = App.student.Name,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start
            };
            layout.Children.Add(lb);


            var lb2 = new Label
            {
                Text = "Lop " + App.student.Grade.ToString(),
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start
            };
            layout.Children.Add(lb2);
            var lb3 = new Label
            {
                Text = App.student.Email,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Start
            };
            layout.Children.Add(lb3);
            var bt = new Button
            {
                Text = "Xem diem bai lam",
                HeightRequest = 50
            };
            bt.Clicked += Bt_Clicked;
            layout.Children.Add(bt);
            Content = layout;
        }

        private void Bt_Clicked(object sender, EventArgs e)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 450,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            this.Navigation.PushModalAsync(new ShowScores(layout)
            {
                BackgroundColor = Color.White,
                Content = layout,
            });
        }
    }
}