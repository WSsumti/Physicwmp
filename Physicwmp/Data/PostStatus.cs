using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Physicwmp.Data
{
    public class PostStatus
    {
        public static void CreatePost(StackLayout layout, string TeacherName, string Context, DateTime dateTime)
        {
            Grid grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition
                    {
                        Height = GridLength.Auto
                    },
                    new RowDefinition
                    {
                        Height = GridLength.Auto
                    }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition
                    {
                        Width = new GridLength(0.1,GridUnitType.Star)
                    },
                    new ColumnDefinition
                    {
                        Width = new GridLength(0.33333,GridUnitType.Star)
                    },
                    new ColumnDefinition
                    {
                        Width = new GridLength(0.33333,GridUnitType.Star)
                    }
                }
            };
            grid.Children.Add(new Image
            {
                Source = "user.png",
                HeightRequest = 25,
                WidthRequest = 25,
            }, 0, 0);
            grid.Children.Add(new Label
            {
                Text = TeacherName,
                FontAttributes = FontAttributes.Bold,
                FontSize = 15
            }, 1, 0);
            grid.Children.Add(new Label
            {
                Text = dateTime.ToString(),
                FontSize = 12,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Start
            }, 2, 0);
            Label lb = new Label() { Text = Context };
            Grid.SetColumnSpan(lb, 3);
            Grid.SetRow(lb, 1);
            grid.Children.Add(lb);
            Frame frame = new Frame()
            {
                Margin = new Thickness(10, 10, 10, 0),
                BorderColor = Color.Black,
                CornerRadius = 5,
                VerticalOptions = LayoutOptions.Fill,
                Content = grid
            };
            layout.Children.Add(frame);
        }
    }
}
