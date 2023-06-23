using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Xamarin.Essentials;
using Physicwmp.Pages;

namespace Physicwmp.Data
{
    public class HomeworkPost 
    {
        public static void PostHomework(StackLayout layout, string HwName, Button bt, string uri)
        {
            Grid grid = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition
                    {
                        Width = new GridLength(0.1, GridUnitType.Star)
                    }
                },
                RowDefinitions =
                {
                    new RowDefinition
                    {
                        Height = GridLength.Auto
                    }
                },    
            };
            Image img = new Image
            {
                Source = "user.png",
                HeightRequest = 25,
                WidthRequest = 25,
                VerticalOptions = LayoutOptions.Start,
                HorizontalOptions = LayoutOptions.Start
            };
            grid.Children.Add(img, 0, 0);
            Label lb = new Label()
            {
                Text = HwName,
            };
            grid.Children.Add(lb, 1, 0);
            //Button bt = new Button()
            //{
            //    Text = "Làm bài!",
            //};
            //bt.Clicked += Bt_Clicked;
            
            grid.Children.Add(bt, 1, 1);
            Frame fr = new Frame()
            {
                Margin = new Thickness(10, 10, 10, 0),
                BorderColor = Color.Black,
                CornerRadius = 5,
                VerticalOptions = LayoutOptions.Fill
            };
            fr.Content = grid;
            layout.Children.Add(fr);
        }

    }
}
