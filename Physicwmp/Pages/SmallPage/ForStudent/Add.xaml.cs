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
    public partial class Add : ContentPage
    {
        public Add(StackLayout layout)
        {
            InitializeComponent();
            StackLayout stack = new StackLayout();
            ScrollView scroll = new ScrollView();
            Label label = new Label()
            {
                Text = "Add Student",
                FontSize = 19,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            layout.Children.Add(label);




            Label label1 = new Label()
            {
                Text = "Họ tên học sinh: ",
                FontSize = 17,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            Entry entry1 = new Entry()
            {
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Frame frame1 = new Frame()
            {
                BorderColor = Color.Black,
                Content = entry1
            };
            stack.Children.Add(label1);
            stack.Children.Add(frame1);
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
            stack.Children.Add(label2);
            stack.Children.Add(frame2);
            CheckBox checkBox1 = new CheckBox()
            {
                HorizontalOptions = LayoutOptions.Center
            };
            CheckBox checkBox2 = new CheckBox()
            {
                HorizontalOptions = LayoutOptions.Center
            };
            Label l1 = new Label()
            {
                Text = "Nam",
                HorizontalOptions = LayoutOptions.End
            };
            Label l2 = new Label()
            {
                Text = "Nữ",
                HorizontalOptions = LayoutOptions.End
            };
            checkBox1.CheckedChanged += (object sender, CheckedChangedEventArgs e) => CheckBox1_CheckedChanged(sender,e, checkBox2);
            checkBox2.CheckedChanged += (object sender, CheckedChangedEventArgs e) => CheckBox2_CheckedChanged(sender, e, checkBox1);
            Grid.SetColumn(checkBox1, 0);
            Grid.SetColumn(checkBox2, 1);
            Grid.SetColumn(l1, 0);
            Grid.SetColumn(l2, 1);

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
                    checkBox1,
                    l1,
                    checkBox2,
                    l2
                }
            };
            stack.Children.Add(grid);

            Label label3 = new Label()
            {
                Text = "Email: ",
                FontSize = 17,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            Entry entry3 = new Entry()
            {
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Frame frame3 = new Frame()
            {
                BorderColor = Color.Black,
                Content = entry3
            };
            stack.Children.Add(label3);
            stack.Children.Add(frame3);

            Label label4 = new Label()
            {
                Text = "Số điện thoại: ",
                FontSize = 17,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            Entry entry4 = new Entry()
            {
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Frame frame4 = new Frame()
            {
                BorderColor = Color.Black,
                Content = entry4
            };
            stack.Children.Add(label4);
            stack.Children.Add(frame4);

            Label label5 = new Label()
            {
                Text = "Username: ",
                FontSize = 17,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            Entry entry5 = new Entry()
            {
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            Frame frame5 = new Frame()
            {
                BorderColor = Color.Black,
                Content = entry5
            };
            stack.Children.Add(label5);
            stack.Children.Add(frame5);


            scroll.Content = stack;
            layout.Children.Add(scroll);
            Button button1 = new Button()
            {
                Text = "Save!",
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center
            };
            button1.Clicked += (object sender, EventArgs e) => Button1_Clicked(sender, e, entry1.Text, Convert.ToInt32(entry2.Text), entry3.Text, Convert.ToInt32(entry4.Text), checkBox1.IsChecked, checkBox2.IsChecked, entry5.Text);
            Grid.SetColumn(button1, 0);
            Button button2 = new Button()
            {
                Text = "Cancel",
                FontSize = 15,
                HorizontalOptions = LayoutOptions.Center
            };
            button2.Clicked += Button2_Clicked;
            Grid.SetColumn(button2, 1);
            Grid grid1 = new Grid()
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
            layout.Children.Add(grid1);
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

        private void Button2_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        private void Button1_Clicked(object sender, EventArgs e, string Name, int Grade, string Email, int Phone, bool girl, bool boy, string username)
        {
            if ((username != null)&&(Name != null)&&(Grade != 0))
            {
                Student student = new Student()
                {
                    Name = Name,
                    Grade = Grade,
                    Phone = Phone,
                    Email = Email,
                    Account = new Account
                    {
                        Username = username,
                        Password = "123456",
                    }
                };
                if (girl)
                {
                    student.isMale = false;
                }
                if (boy)
                {
                    student.isMale = true;
                }

                HttpClient client = new HttpClient();
                var create = client.PostAsJsonAsync<Student>("https://physicwmp.herokuapp.com/api/students/", student);
                create.Wait();
                this.DisplayAlert("Notification!", "Save successfully", "Ok");
                this.Navigation.PopModalAsync(); 
            }
            else if (Name == null)
            {
                this.DisplayAlert("Notification!", "Không được bỏ trống tên", "Ok");
            } else if (Grade == 0)
            {
                this.DisplayAlert("Notification!", "Không được bỏ trống lớp", "Ok");
            } else if (username == null)
            {
                this.DisplayAlert("Notification!", "Không được bỏ trống tên tài khoản", "Ok");
            }
        }

        
    }
}