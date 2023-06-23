using Physicwmp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physicwmp.Pages.SmallPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Noti : ContentPage
    {
        public Noti(StackLayout layout, int Grade)
        {
            InitializeComponent();
            Button button = new Button()
            {
                Text = "Close!",
                HorizontalOptions = LayoutOptions.End,
            };
            button.Clicked += Button_Clicked;
            layout.Children.Add(button);
            UI(layout, Grade);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        public async void UI(StackLayout layout, int Grade)
        {
            StackLayout stackLayout1 = new StackLayout();
            ScrollView scrollView = new ScrollView();
            Label label = new Label()
            {
                Text = "Lớp " + Grade.ToString(),
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            layout.Children.Add(label);
            Services ser = new Services();
            var notis = await ser.GetAllNotification(Grade);
            foreach (var noti in notis)
            {
                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                };
                StackLayout stackLayout = new StackLayout();
                Label label1 = new Label()
                {
                    Text = noti.TimeUpload.ToString(),
                    FontSize = 12,
                    Margin = new Thickness(10,10,0,0),
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                };
                stackLayout.Children.Add(label1);
                Label label2 = new Label()
                {
                    Text = noti.TeacherName,
                    FontSize = 15,
                    Margin = new Thickness(10, 10, 0, 0),
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                stackLayout.Children.Add(label2);
                Label label3 = new Label()
                {
                    Text = noti.Content,
                    FontSize = 15,
                    Margin = new Thickness(10, 10, 0, 0),
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                stackLayout.Children.Add(label3);
                Button button = new Button()
                {
                    Text = "Delete!",
                    FontSize = 17,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                };
                button.Clicked += (object sender, EventArgs e) => Button_Clicked1(sender,e,noti.Id,Grade);
                stackLayout.Children.Add(button);
                frame.Content = stackLayout;
                stackLayout1.Children.Add(frame);
            }
            scrollView.Content = stackLayout1;
            layout.Children.Add(scrollView);
        }

        private async void Button_Clicked1(object sender, EventArgs e, Guid id, int Grade)
        {
            bool ans = await DisplayAlert("Warning!", "Do you really want to delete this notification", "Ok", "Cancel");
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
    }
}