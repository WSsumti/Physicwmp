
using Newtonsoft.Json;
using Physicwmp.Data;
using Physicwmp.Pages.SmallPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physicwmp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OnClass : ContentPage
    {
        public OnClass()
        {
            InitializeComponent();
            UI(layout);
        }
        public async void UI(StackLayout layout)
        {
            HttpClient client = new HttpClient();
            List<Document> dcms = new List<Document>();
            string ri = "https://physicwmp.herokuapp.com/api/documents/" + App.student.Grade.ToString();
            Uri uri = new Uri(ri);
            HttpResponseMessage res = await client.GetAsync(uri);
            res.EnsureSuccessStatusCode();
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
                dcms = JsonConvert.DeserializeObject<List<Document>>(content);
            }
            StackLayout stack = new StackLayout();
            ScrollView scroll = new ScrollView();
            foreach (var dcm in dcms)
            {
                StackLayout stackLayout = new StackLayout();
                Image image = new Image()
                {
                    Source = "user.png",
                    HeightRequest = 25,
                    WidthRequest = 25,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                stackLayout.Children.Add(image);
                Label label = new Label()
                {
                    Text = "Tên bài: " + dcm.Name,
                    FontSize = 15,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Margin = new Thickness(30, 0, 0, 0),
                };
                stackLayout.Children.Add(label);
                Button button = new Button()
                {
                    Text = "Coi thôi nào!",
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                };
                button.Clicked += (object sender, EventArgs e) => Button_Clicked(sender, e, dcm.URL);
                stackLayout.Children.Add(button);
                Frame frame = new Frame()
                {
                    Content = stackLayout,
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                };
                stack.Children.Add(frame);

            }
            scroll.Content = stack;
            layout.Children.Add(scroll);
        }

        private void Button_Clicked(object sender, EventArgs e, string url)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 450,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            this.Navigation.PushModalAsync(new ShowDocument(layout, url)
            {
                BackgroundColor = Color.White,
                Content = layout,
            });
        }
    }
}