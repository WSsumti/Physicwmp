using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Physicwmp.Data;
using System.Net.Http;

namespace Physicwmp.Pages.SmallPage.ForDocs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : ContentPage
    {
        public Add(string purpose)
        {
            InitializeComponent();
            UI(layout, purpose);
        }
        public void UI(StackLayout layout,string purpose)
        {
            List<char> ans = new List<char>();
            StackLayout stack = new StackLayout();
            Button close = new Button()
            {
                Text = "Close",
                FontSize = 15,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            close.Clicked += Close_Clicked;
            layout.Children.Add(close);

            Label title = new Label()
            {
                Text = purpose,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            layout.Children.Add(title);

            Label label = new Label()
            {
                Text ="",
                FontSize = 15,
            };
            if (purpose == "Homework")
            {
                label.Text = "Tên bài tập: ";
            }else
            {
                label.Text = "Tên tài liệu: ";
            }
            stack.Children.Add(label);

            Entry entry = new Entry()
            {
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Frame frame = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                Content = entry,
            };
            stack.Children.Add(frame);

            Label label2 = new Label()
            {
                Text = "Lớp: ",
                FontSize = 15,
            };
            stack.Children.Add(label2);
            Entry entry3 = new Entry()
            {
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Frame frame3 = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                Content = entry3,
            };
            stack.Children.Add(frame3);
            CheckBox checkBox1 = new CheckBox()
            {
                HorizontalOptions = LayoutOptions.Center
            };
            CheckBox checkBox2 = new CheckBox()
            {
                HorizontalOptions = LayoutOptions.Center
            };
            if (purpose == "Document")
            {
                Label label1 = new Label()
                {
                    Text = "Video hay Tài liệu",
                    FontSize = 15,
                };
               
                
                Label l1 = new Label()
                {
                    Text = "Video",
                    HorizontalOptions = LayoutOptions.End
                };
                Label l2 = new Label()
                {
                    Text = "Tài liệu",
                    HorizontalOptions = LayoutOptions.End
                };
                checkBox1.CheckedChanged += (object sender, CheckedChangedEventArgs e) => CheckBox1_CheckedChanged(sender, e, checkBox2);
                checkBox2.CheckedChanged += (object sender, CheckedChangedEventArgs e) => CheckBox2_CheckedChanged(sender, e, checkBox1);
                Grid.SetColumn(checkBox1, 0);
                Grid.SetColumn(checkBox2, 1);
                Grid.SetColumn(l1, 0);
                Grid.SetColumn(l2, 1);
                Grid grid = new Grid()
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition()
                        {
                            Width = new GridLength(0.5,GridUnitType.Star),
                        },
                        new ColumnDefinition()
                        {
                            Width = new GridLength(0.5,GridUnitType.Star),
                        },
                    },
                    Children =
                    {
                        checkBox1,
                        l1,
                        checkBox2,
                        l2
                    },
                };
                stack.Children.Add(grid);
            }


            var web = new WebView()
            {
                Source = "https://www.google.com",
                HeightRequest = 480,
            };
            Frame frame1 = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                Content = web,
            };
            stack.Children.Add(frame1);
            Entry entry1 = new Entry()
            {
                FontSize = 12,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            web.Navigated += (object sender, WebNavigatedEventArgs e) => Web_Navigated(sender,e,entry1);
            
            Frame frame2 = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                Content = entry1,
            };
            stack.Children.Add(frame2);
            

            
            ScrollView scroll = new ScrollView();
            scroll.Content = stack;
            layout.Children.Add(scroll);
            if (purpose == "Homework")
            {
                Label label1 = new Label()
                {
                    Text = "Số câu hỏi: ",
                    FontSize = 15,
                };
                stack.Children.Add(label1);
                Entry entry2 = new Entry()
                {
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                };
                stack.Children.Add(entry2);

                HomeworkAnswer aa = new HomeworkAnswer()
                {
                    BackgroundColor = Color.White,
                };
                Button bt = new Button()
                {
                    Text = "Nhập câu trả lời",
                    FontSize = 12,
                };
                stack.Children.Add(bt);
                bt.Clicked += (object sender, EventArgs e) => AddHomework(sender, e, Convert.ToInt32(entry2.Text), aa);
                Button save = new Button()
                {
                    Text = "Save",
                    FontSize = 13,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                save.Clicked += (object sender, EventArgs e) => Save_Clicked(sender, e, entry, entry1, Convert.ToInt32(entry2.Text), aa.a, entry3);
                layout.Children.Add(save);
            }
            else
            {
                Button save = new Button()
                {
                    Text = "Save",
                    FontSize = 13,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                save.Clicked += (object sender, EventArgs e) => Save_Clicked1(sender, e, entry, entry1, entry3, checkBox1, checkBox2);
                layout.Children.Add(save);
            }
            
        }

        private void CheckBox2_CheckedChanged(object sender, CheckedChangedEventArgs e, CheckBox check)
        {
            if (check.IsChecked)
            {
                check.IsChecked = false;
            }
        }

        private void CheckBox1_CheckedChanged(object sender, CheckedChangedEventArgs e, CheckBox check)
        {
            if (check.IsChecked)
            {
                check.IsChecked = false;
            }
        }

        private void AddHomework(object sender, EventArgs e, int n, HomeworkAnswer an)
        {
            if (n != 0)
            {
                StackLayout l = new StackLayout()
                {
                    WidthRequest = 350,
                    HeightRequest = 450,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                an.Content = l;
                an.UI(l, n);
                this.Navigation.PushModalAsync(an);
            }
            else
                this.DisplayAlert("Notification!", "Chưa nhập số câu trả lời", "Ok");
        }

        private void An_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save_Clicked1(object sender, EventArgs e, Entry title, Entry url,Entry grade, CheckBox b1, CheckBox b2)
        {
            if (title.Text == null || url.Text == null || grade.Text == null || (b1.IsChecked == false) && (b2.IsChecked == false)) 
            {
                this.DisplayAlert("Notification: ", "Nhập thiếu dữ liệu!", "Ok");
                 
            }
            else
            {
                Document doc = new Document();
                if (b1.IsChecked)
                {

                    doc.Name = title.Text;
                    doc.URL = url.Text;
                    doc.IsVideo = true;
                }
                else
                {
                    doc.Name = title.Text;
                    doc.URL = url.Text;
                    doc.IsVideo = true;
                }
                HttpClient client = new HttpClient();
                string rl = "https://physicwmp.herokuapp.com/api/documents/" + grade.Text;
                Uri uri = new Uri(rl);
                var create = client.PostAsJsonAsync<Document>(uri, doc);
                create.Wait();
                this.DisplayAlert("Notification: ", "Nhập thành công!", "Ok");
                this.Navigation.PopModalAsync();
            }
        }

        private void Save_Clicked(object sender, EventArgs e, Entry title, Entry url, int n, List<char> an, Entry grade)
        {
            //ktra
            if (title.Text == null || url.Text == null || grade.Text == null || an.Count ==0) 
            {
                this.DisplayAlert("Notification: ", "Nhập thiếu dữ liệu!", "Ok");
            }
            else
            {
                HomeworkModel hw = new HomeworkModel()
                {
                    Name = title.Text,
                    URL = url.Text,
                    Answer = an,
                };
                HttpClient client = new HttpClient();
                string rl = "https://physicwmp.herokuapp.com/api/homeworks/" + grade.Text;
                Uri uri = new Uri(rl);
                var create = client.PostAsJsonAsync<HomeworkModel>(uri, hw);
                create.Wait();
                this.DisplayAlert("Notification: ", "Nhập thành công!", "Ok");
                this.Navigation.PopModalAsync();
            }
        }

        private void Web_Navigated(object sender, WebNavigatedEventArgs e, Entry entry)
        {
            entry.Text = e.Url;
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}