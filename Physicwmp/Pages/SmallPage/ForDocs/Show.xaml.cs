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

namespace Physicwmp.Pages.SmallPage.ForDocs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Show : ContentPage
    {
        public Show(StackLayout layout, string purpose)
        {
            InitializeComponent();
            UI(layout, purpose);
        }
        public async void UI(StackLayout layout, string purpose)
        {
            Services ser = new Services();
            ScrollView scroll = new ScrollView();
            StackLayout stackLayout = new StackLayout();
            Button Close = new Button()
            {
                Text = "Close",
                FontSize = 12,
            };
            Close.Clicked += Close_Clicked;
            layout.Children.Add(Close);
            Label label = new Label()
            {
                Text = purpose,
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            layout.Children.Add(label);
            if (purpose == "Homeworks")
            {
                for (int grade = 10; grade <=12; ++grade)
                {
                    var homeworks = await ser.GetAllHomeworks(grade);
                    Label label1 = new Label()
                    {
                        Text ="Lớp " + grade.ToString(),
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                    };
                    stackLayout.Children.Add(label1);
                    foreach (var homework in homeworks)
                    {
                        StackLayout stack = new StackLayout();
                        Frame frame = new Frame()
                        {
                            BorderColor = Color.Black,
                            CornerRadius = 5,
                        };
                        Label label2 = new Label()
                        {
                            Text = homework.Name,
                            FontSize = 15,
                            HorizontalOptions = LayoutOptions.StartAndExpand,
                        };
                        stack.Children.Add(label2);
                        Button more = new Button()
                        {
                            Text = "More",
                            FontSize = 13,
                            HorizontalOptions = LayoutOptions.EndAndExpand,
                        };
                        more.Clicked += (object sender, EventArgs e) => More_Clicked(sender, e, grade, homework);
                        stack.Children.Add(more);
                        frame.Content = stack;
                        stackLayout.Children.Add(frame);
                    }
                    scroll.Content = stackLayout;
                    layout.Children.Add(scroll);
                }
            }
            else
            {
                for (int grade = 10; grade <= 12; ++grade)
                {
                    var dcms = await GetDocuments(grade);
                    Label label1 = new Label()
                    {
                        Text = "Lớp " + grade.ToString(),
                        FontSize = 20,
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                    };
                    stackLayout.Children.Add(label1);
                    foreach (var dcm in dcms)
                    {
                        StackLayout stack = new StackLayout();
                        Frame frame = new Frame()
                        {
                            BorderColor = Color.Black,
                            CornerRadius = 5,
                        };
                        Label label2 = new Label()
                        {
                            Text = dcm.Name,
                            FontSize = 15,
                            HorizontalOptions = LayoutOptions.StartAndExpand,
                        };
                        stack.Children.Add(label2);
                        Button more = new Button()
                        {
                            Text = "More",
                            FontSize = 13,
                            HorizontalOptions = LayoutOptions.EndAndExpand,
                        };
                        more.Clicked += (object sender, EventArgs e) => More_ClickedDoc(sender, e, grade, dcm);
                        stack.Children.Add(more);
                        frame.Content = stack;
                        stackLayout.Children.Add(frame);
                    }
                    

                    scroll.Content = stackLayout;
                    layout.Children.Add(scroll);
                }
            }
        }

        private async void More_ClickedDoc(object sender, EventArgs e, int grade, Document dcm)
        {
            var more = await DisplayActionSheet("More", "Cancel", null, "View", "Delete");
            switch (more)
            {
                case "Delete":
                    HttpClient client = new HttpClient();
                    Uri uri = new Uri("https://physicwmp.herokuapp.com/api/documents/" + grade.ToString() + dcm.Id.ToString());
                    var delete = client.DeleteAsync(uri);
                    delete.Wait();
                    break;
                case "View":
                    StackLayout layout = new StackLayout()
                    {
                        WidthRequest = 350,
                        HeightRequest = 450,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };
                    await Navigation.PushModalAsync(new ViewDoc(layout, dcm)
                    {
                        BackgroundColor = Color.White,
                        Content = layout
                    });
                    break;


            }
        }

        private async void More_Clicked(object sender, EventArgs e, int Grade, HomeworkModel hw)
        {
            var more = await DisplayActionSheet("More", "Cancel", null, "View", "Delete");
            switch (more)
            {
                case "Delete":
                    HttpClient client = new HttpClient();
                    Uri uri = new Uri("https://physicwmp.herokuapp.com/api/homeworks/" + Grade.ToString() + hw.Id.ToString());
                    var delete = client.DeleteAsync(uri);
                    delete.Wait();
                    break;
                case "View":
                    StackLayout layout = new StackLayout()
                    {
                        WidthRequest = 350,
                        HeightRequest = 450,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        VerticalOptions = LayoutOptions.CenterAndExpand
                    };
                    await Navigation.PushModalAsync(new ViewUpdateDoc(layout, hw)
                    {
                        BackgroundColor = Color.White,
                        Content = layout
                    });
                    break;
                

            }
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
        private async Task<List<Document>> GetDocuments(int grade)
        {
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://physicwmp.herokuapp.com/api/documents/" + grade.ToString());
            var get = await client.GetStringAsync(uri);
            List<Document> documents = JsonConvert.DeserializeObject<List<Document>>(get);
            return documents;
        }
    }
}