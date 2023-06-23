using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MongoDB.Bson.Serialization.Attributes;
using Physicwmp.Data;

namespace Physicwmp.Pages.SmallPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Update : ContentPage
    {
        public Update(StackLayout layout)
        {
            InitializeComponent();
            Button button = new Button()
            {
                Text = "Close",
                HeightRequest = 30,
                HorizontalOptions = LayoutOptions.End,
            };
            button.Clicked += Button_Clicked;
            layout.Children.Add(button);
            UI(layout);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        private async void Bt_Clicked(object sender, EventArgs e, int Grade, Guid id)
        {
            bool ans = await DisplayAlert("Warning!", "Do you want to delete this notification?", "Ok!", "Cancel");
            if (ans)
            {
                HttpClient client = new HttpClient();
                string ri = "https://physicwmp.herokuapp.com/api/notifications/" + id.ToString() + "/" + Grade.ToString();
                Uri uri = new Uri(ri);
                var delete = client.DeleteAsync(uri);
                delete.Wait();
                await Navigation.PopModalAsync();
            }
        }

        public async void UI(StackLayout layout)
        {
            
            StackLayout stackL = new StackLayout();
            stackL.Children.Add(new Label
            {
                Text = "Lớp 10",
                FontSize = 20,
                Margin = new Thickness(10,10,0,0),
                FontAttributes = FontAttributes.Bold,
            });
            Services ser = new Services();
            var noti10 = await ser.GetAllNotification(10);
            foreach (var noti in noti10)
            {
                StackLayout stack = new StackLayout();
                ImageButton bt = new ImageButton()
                {
                    Source = "more.png",
                    HeightRequest = 25,
                    VerticalOptions = LayoutOptions.End,
                    BackgroundColor = Color.White,
                };
                bt.Clicked += (object sender, EventArgs e) => Bt_Clicked(sender, e, 10, noti.Id);
                //UI(layout, bt, noti.TeacherName, noti.Content);

                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                };
                //Image image = new Image()
                //{
                //    Source = "user.png",
                //    WidthRequest = 25,
                //    HeightRequest = 25,
                //    //Margin = new Thickness(10, 10, 0, 0),
                //    VerticalOptions = LayoutOptions.CenterAndExpand,

                //};
                //Grid.SetColumn(image, 0);
                Label label = new Label()
                {
                    Text = noti.TeacherName,
                    FontSize = 15,
                    Margin = new Thickness(10, 10, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                };
                
                Label label1 = new Label()
                {
                    Text = noti.Content,
                    FontSize = 15,
                    Margin = new Thickness(10, 10, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                };

                Label label2 = new Label()
                {
                    Text = noti.TimeUpload.ToString(),
                    FontSize = 12,
                    Margin = new Thickness(10, 10, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                };

                

                stack.Children.Add(label2);
                stack.Children.Add(label);
                stack.Children.Add(label1);
                stack.Children.Add(bt);
                
                frame.Content = stack;

                
                stackL.Children.Add(frame);
                

            }
            stackL.Children.Add(new Label
            {
                Text = "Lớp 11",
                FontSize = 20,
                Margin = new Thickness(10, 10, 0, 0),
                FontAttributes = FontAttributes.Bold,
            });
            
            var noti11 = await ser.GetAllNotification(11);
            foreach (var noti in noti11)
            {
                StackLayout stack = new StackLayout();
                ImageButton bt = new ImageButton()
                {
                    Source = "more.png",
                    HeightRequest = 25,
                    VerticalOptions = LayoutOptions.End,
                    BackgroundColor = Color.White,
                };
                bt.Clicked += (object sender, EventArgs e) => Bt_Clicked(sender, e, 11, noti.Id);
                //UI(layout, bt, noti.TeacherName, noti.Content);

                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                };
                //Image image = new Image()
                //{
                //    Source = "user.png",
                //    WidthRequest = 25,
                //    HeightRequest = 25,
                //    //Margin = new Thickness(10, 10, 0, 0),
                //    VerticalOptions = LayoutOptions.CenterAndExpand,

                //};
                //Grid.SetColumn(image, 0);
                Label label = new Label()
                {
                    Text = noti.TeacherName,
                    FontSize = 15,
                    Margin = new Thickness(10, 10, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                };

                Label label1 = new Label()
                {
                    Text = noti.Content,
                    FontSize = 15,
                    Margin = new Thickness(10, 10, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                };

                Label label2 = new Label()
                {
                    Text = noti.TimeUpload.ToString(),
                    FontSize = 12,
                    Margin = new Thickness(10, 10, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                };



                stack.Children.Add(label2);
                stack.Children.Add(label);
                stack.Children.Add(label1);
                stack.Children.Add(bt);

                frame.Content = stack;


                stackL.Children.Add(frame);


            }

            stackL.Children.Add(new Label
            {
                Text = "Lớp 12",
                FontSize = 20,
                Margin = new Thickness(10, 10, 0, 0),
                FontAttributes = FontAttributes.Bold,
            });

            var noti12 = await ser.GetAllNotification(12);
            foreach (var noti in noti12)
            {
                StackLayout stack = new StackLayout();
                ImageButton bt = new ImageButton()
                {
                    Source = "more.png",
                    HeightRequest = 25,
                    VerticalOptions = LayoutOptions.End,
                    BackgroundColor = Color.White,
                };
                bt.Clicked += (object sender, EventArgs e) => Bt_Clicked(sender, e, 12, noti.Id);
                //UI(layout, bt, noti.TeacherName, noti.Content);

                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                };
                //Image image = new Image()
                //{
                //    Source = "user.png",
                //    WidthRequest = 25,
                //    HeightRequest = 25,
                //    //Margin = new Thickness(10, 10, 0, 0),
                //    VerticalOptions = LayoutOptions.CenterAndExpand,

                //};
                //Grid.SetColumn(image, 0);
                Label label = new Label()
                {
                    Text = noti.TeacherName,
                    FontSize = 15,
                    Margin = new Thickness(10, 10, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                };

                Label label1 = new Label()
                {
                    Text = noti.Content,
                    FontSize = 15,
                    Margin = new Thickness(10, 10, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                };

                Label label2 = new Label()
                {
                    Text = noti.TimeUpload.ToString(),
                    FontSize = 12,
                    Margin = new Thickness(10, 10, 0, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                };



                stack.Children.Add(label2);
                stack.Children.Add(label);
                stack.Children.Add(label1);
                stack.Children.Add(bt);

                frame.Content = stack;


                stackL.Children.Add(frame);


            }


            ScrollView scroll = new ScrollView();
            scroll.Content = stackL;
            layout.Children.Add(scroll);


        }

    }
}