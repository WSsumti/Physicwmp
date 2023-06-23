using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using Physicwmp.Data;

namespace Physicwmp.Pages.SmallPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        public Add(StackLayout layout)
        {
            InitializeComponent();
            StackLayout stack = new StackLayout();
            ScrollView scroll = new ScrollView();
            Label label = new Label()
            {
                Text = "Add Notifications",
                FontSize = 19,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            layout.Children.Add(label);


            Label label1 = new Label()
            {
                Text = "Họ tên giáo viên: ",
                FontSize = 17,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            Entry entry1 = new Entry()
            {
                Text = App.teacher.Name,
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Frame frame1 = new Frame()
            {
                BorderColor = Color.Black,
                Content = entry1
            };
            Label label2 = new Label()
            {
                Text = "Lớp: ",
                FontSize = 17,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            Entry entry2 = new Entry()
            {
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Frame frame2 = new Frame()
            {
                BorderColor = Color.Black,
                Content = entry2
            };
            Label label3 = new Label()
            {
                Text = "Nội dung: ",
                FontSize = 17,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            Editor edit1 = new Editor()
            {
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 100
            };
            Frame frame3 = new Frame()
            {
                HeightRequest = 100,
                BorderColor = Color.Black,
                Content = edit1
            };
            stack.Children.Add(label1);
            stack.Children.Add(frame1);
            stack.Children.Add(label2);
            stack.Children.Add(frame2);
            stack.Children.Add(label3);
            stack.Children.Add(frame3);


            scroll.Content = stack;
            layout.Children.Add(scroll);
            Button button1 = new Button()
            {
                Text = "Save!",
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center
            };
            button1.Clicked += (object sender, EventArgs e) => Button1_Clicked(sender, e, entry2.Text, edit1.Text);
            Grid.SetColumn(button1, 0);
            Button button2 = new Button()
            {
                Text = "Cancel",
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center
            };
            button2.Clicked += Button2_Clicked;
            Grid.SetColumn(button1, 1);
            Grid grid = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition
                    {
                        Width = new GridLength(0.55555,GridUnitType.Star)
                    },
                    new ColumnDefinition
                    {
                        Width = new GridLength(0.55555,GridUnitType.Star)
                    }

                },
                Children =
                {
                    button1,
                    button2
                }
            };
            layout.Children.Add(grid);
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        private void Button1_Clicked(object sender, EventArgs e, string Grade, string Content)
        {
            var noti = new Notification()
            {
                TeacherName = App.teacher.Name,
                Content = Content,
                TimeUpload = DateTime.Now
            };
            HttpClient client = new HttpClient();
            string ri = "https://physicwmp.herokuapp.com/api/notifications/" + Grade.ToString();
            Uri uri = new Uri(ri);
            var post = client.PostAsJsonAsync<Notification>(uri, noti);
            post.Wait();
            this.Navigation.PopModalAsync();
        }

        public void DoView(StackLayout layout, string TeacherName)
        {
            
            
            
        }
    }
}