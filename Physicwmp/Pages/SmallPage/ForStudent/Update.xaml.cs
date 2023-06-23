using Physicwmp.Data;
using Physicwmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physicwmp.Pages.SmallPage.ForStudent
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Update : ContentPage
    {
        public Update(StackLayout layout, int Grade)
        {
            InitializeComponent();
            UI(layout, Grade);
        }
        public async void UI(StackLayout layout, int Grade)
        {
            StackLayout stackLayout1 = new StackLayout();
            ScrollView scrollView = new ScrollView();
            Button close = new Button()
            {
                Text = "Close",
                FontSize = 12,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            close.Clicked += Close_Clicked;
            layout.Children.Add(close);
            Label label = new Label()
            {
                Text = "Lớp "+Grade.ToString(),
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            layout.Children.Add(label);
            Services ser = new Services();
            var students = await ser.GetAllStudents();
            foreach (var student in students)
            {
                if (student.Grade == Grade)
                {
                    Frame frame = new Frame()
                    {
                        BorderColor = Color.Black,
                        CornerRadius = 5,
                    };
                    StackLayout stackLayout = new StackLayout();
                    Label label1 = new Label()
                    {
                        Text = student.Name,
                        FontSize = 12,
                        Margin = new Thickness(10, 10, 0, 0),
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                    };
                    stackLayout.Children.Add(label1);
                    Label label2 = new Label()
                    {
                        Text = student.Grade.ToString(),
                        FontSize = 15,
                        Margin = new Thickness(10, 10, 0, 0),
                        HorizontalOptions = LayoutOptions.StartAndExpand,
                    };
                    
                    Button button = new Button()
                    {
                        Text = "More",
                        FontSize = 17,
                        HorizontalOptions = LayoutOptions.EndAndExpand,
                    };
                    button.Clicked += (object sender, EventArgs e) => Button_Clicked1(sender, e, student);
                    stackLayout.Children.Add(button);
                    frame.Content = stackLayout;
                    stackLayout1.Children.Add(frame); 
                }
            }
            
            
            scrollView.Content = stackLayout1;
            layout.Children.Add(scrollView);
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        private async void Button_Clicked1(object sender, EventArgs e, Student student)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 450,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            string ans =  await DisplayActionSheet("More", "Cancel", null, "View", "Update", "Delete");
            switch (ans)
            {
                case "View":
                    
                     await Navigation.PushModalAsync(new ActionSheetss(layout, "View", student)
                    {
                        BackgroundColor = Color.White,
                        Content = layout
                    });
                    break;
                case "Update":
                    await Navigation.PushModalAsync(new ActionSheetss(layout, "Update", student)
                    {
                        BackgroundColor = Color.White,
                        Content = layout
                    });
                    break;
                case "Delete":
                    string ri = "https://physicwmp.herokuapp.com/api/students/" + student.Account.Username;
                    Uri uri = new Uri(ri);
                    HttpClient client = new HttpClient();
                    var delete = client.DeleteAsync(uri);
                    delete.Wait();
                    await DisplayAlert("Notification", "Delete successfully","Ok");
                    await Navigation.PopModalAsync();
                    break;
            }
        }
    }
}