using Physicwmp;
using Physicwmp.Data;
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
    public partial class DoingHw : ContentPage
    {
        public DoingHw(string url,List<char> an, HomeworkModel hw, DateTime dt)
        {
            InitializeComponent();
            InitialHW(layout, an, url, hw, dt);
            
        }
        public void InitialHW(StackLayout layout, List<char> ans, string url, HomeworkModel hw, DateTime dt)
        {
            int points = 0;
            List<char> s_ans = new List<char>();
            List<Entry> en_ans = new List<Entry>();
            Frame fr1 = new Frame()
            {
                BorderColor = Color.Black,
                Margin = new Thickness(0, 1, 0, 0),
                BackgroundColor = Color.Black,
                HeightRequest = 480,
                Content = new WebView()
                {
                    Source = url
                }
            };
            layout.Children.Add(fr1);

            StackLayout lay = new StackLayout();
            for (int i = 1; i <= ans.Count; ++i)
            {
                var frame = Ans(i.ToString(), en_ans);
                StackLayout stackLayout = new StackLayout();
                stackLayout.Children.Add(frame);
                lay.Children.Add(stackLayout);
            };

            Frame fr2 = new Frame()
            {
                HeightRequest = 100,
                BorderColor = Color.Red,
            };

            ScrollView scr = new ScrollView();
            scr.Content = lay;
            fr2.Content = scr;
            layout.Children.Add(fr2);

            Grid gr = new Grid()
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition
                    {
                        Width = new GridLength(0.25,GridUnitType.Star)
                    },
                    new ColumnDefinition
                    {
                        Width = new GridLength(0.5,GridUnitType.Star)
                    },
                    new ColumnDefinition
                    {
                        Width = new GridLength(0.25,GridUnitType.Star)
                    }
                }
            };
            Label lb = new Label()
            {
                Text = "GoodLuck :) -------->",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            Grid.SetColumn(lb, 1);
            gr.Children.Add(lb);
            Button bt = new Button()
            {
                Text = "Nop bai!",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            Grid.SetColumn(bt, 2);
            bt.Clicked += (object sender, EventArgs e) => Bt_Clicked(sender, e, s_ans, en_ans, ans, points, hw, dt);
            gr.Children.Add(bt);
            layout.Children.Add(gr);
        }

        private void Bt_Clicked(object sender, EventArgs e, List<char> an, List<Entry> en, List<char> ans, int points, HomeworkModel cur, DateTime timestart)
        {
            foreach (var q in en)
            {

                if (q.Text != null)
                {
                    var x = q.Text.ToCharArray();
                    an.Add(x[0]);
                }
                else
                {
                    char x = '*';
                    an.Add(x);
                }
            }

            for (int i = 0; i < ans.Count; ++i)
            {
                if (an[i] == ans[i])
                {
                    ++points;
                }
            }
            this.DisplayAlert("Nộp bài thành công! ", "Số câu đúng: " + points.ToString(), "Ok");
            DateTime end = new DateTime();
            end = DateTime.Now;
            Test curtest = new Test()
            {
                NameTest = cur.Name,
                Score = (double)points / an.Count * 10,
                TimeStart = timestart,
                TimeEnd = end,
                RightAns = points,
                SumofQuestion = an.Count,
            };
            List<Test> result = App.student.Test;
            result.Add(curtest);
            Student student = App.student;
            student.Test = result;
            HttpClient client = new HttpClient();
            string ri = "https://physicwmp.herokuapp.com/api/students/" + student.Account.Username;
            Uri uri = new Uri(ri);
            var delete = client.DeleteAsync(uri);
            delete.Wait();
            var create = client.PostAsJsonAsync<Student>("https://physicwmp.herokuapp.com/api/students/", student);
            create.Wait();
            App.student = student;
            this.Navigation.PopModalAsync();
        }

        public Frame Ans(string so, List<Entry> entries)
        {
            Label lb = new Label()
            {
                Text = "Câu " + so,
                VerticalOptions = LayoutOptions.StartAndExpand,
                FontSize = 15,
                Margin = new Thickness(0, 13, 0, 0)
            };
            Grid.SetColumn(lb, 0);

            Entry en = new Entry()
            {
                Placeholder = "Nhập đáp án: ",
                VerticalOptions = LayoutOptions.StartAndExpand,
                FontSize = 15,
            };
            Grid.SetColumn(en, 1);

            entries.Add(en);

            Frame fr = new Frame()
            {
                HeightRequest = 40,
                Content = new Grid()
                {
                    ColumnDefinitions =
                    {
                        new ColumnDefinition
                        {
                            Width = new GridLength(0.3,GridUnitType.Star)
                        },
                        new ColumnDefinition
                        {
                            Width = new GridLength(0.7,GridUnitType.Star)
                        }
                    },
                    Children =
                    {
                        lb,
                        en
                    }
                }
            };
            return fr;
        }
    }
}