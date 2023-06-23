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
    public partial class ActionSheetss : ContentPage
    {
        public ActionSheetss(StackLayout layout, string taks, Student student)
        {
            InitializeComponent();
            if (taks == "View")
            {
                UI(layout, student);
            }
            else
            {
                UI2(layout, student);
            }
        }
        public void UI(StackLayout layout, Student student)
        {
            
            Button button = new Button()
            {
                Text = "Close!",
                HorizontalOptions = LayoutOptions.End,
            };
            button.Clicked += Button_Clicked;
            layout.Children.Add(button);
            ScrollView scroll = new ScrollView();
            StackLayout stackLayout = new StackLayout();
            Label label = new Label()
            {
                Text = "Thông tin học sinh",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            stackLayout.Children.Add(label);
            Label label1 = new Label()
            {
                Text = "Họ và tên: " + student.Name,
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Frame frame1 = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content = label1,
            };
            stackLayout.Children.Add(frame1);

            Label label2 = new Label()
            {
                Text = "Lớp: " + student.Grade,
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Frame frame2 = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content = label2,
            };
            stackLayout.Children.Add(frame2);

            Label label3 = new Label()
            {
                Text = "Email: " + student.Email,
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Frame frame3 = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content = label3,
            };
            stackLayout.Children.Add(frame3);

            

            Label label5 = new Label()
            {
                Text = "Số điện thoại: " + student.Phone,
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Frame frame5 = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content = label5,
            };
            stackLayout.Children.Add(frame5);

            Label label6 = new Label()
            {
                Text = "Tên tài khoản: " + student.Account.Username,
                FontSize = 15,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            Frame frame6 = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Content = label6,
            };
            stackLayout.Children.Add(frame6);
            scroll.Content = stackLayout;
            layout.Children.Add(scroll);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
        public void UI2(StackLayout layout, Student student)
        {
            
            Student temp = new Student();
            Button button = new Button()
            {
                Text = "Close!",
                HorizontalOptions = LayoutOptions.End,
            };
            button.Clicked += Button_Clicked;
            layout.Children.Add(button);
            ScrollView scroll = new ScrollView();
            StackLayout stackLayout = new StackLayout();
            Label label = new Label()
            {
                Text = "Thông tin học sinh",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            stackLayout.Children.Add(label);

            Label label1 = new Label()
            {
                Text = "Họ và tên: ",
                FontSize = 15,
            };
            stackLayout.Children.Add(label1);
            Entry entry = new Entry();
            if (student.Name != null)
            {

                entry.Text = student.Name;
                entry.FontSize = 15;
                entry.HorizontalOptions = LayoutOptions.FillAndExpand;
               
                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Content = entry,
                };
                stackLayout.Children.Add(frame);
                //name = entry.Text;
            }
            else
            {

                entry.FontSize = 15;
                entry.HorizontalOptions = LayoutOptions.FillAndExpand;
                
                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Content = entry,
                };
                stackLayout.Children.Add(frame);
                //temp.Name = entry.Text;
            }

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
            if (student.isMale)
            {
                checkBox1.IsChecked = true;
            }
            else
            {
                checkBox2.IsChecked = true;
            }
            checkBox1.CheckedChanged += (object sender, CheckedChangedEventArgs e) => CheckBox1_CheckedChanged(sender, e, checkBox2);
            checkBox2.CheckedChanged += (object sender, CheckedChangedEventArgs e) => CheckBox2_CheckedChanged(sender, e, checkBox1);
            stackLayout.Children.Add(grid);

            Label label2 = new Label()
            {
                Text = "Lớp: " ,
                FontSize = 15,
            };
            stackLayout.Children.Add(label2);
            Entry entry1 = new Entry();
            if (student.Grade != 0)
            {

                entry1.Text = student.Grade.ToString();
                entry1.FontSize = 15;
                entry1.HorizontalOptions = LayoutOptions.FillAndExpand;
                
                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Content = entry1,
                };
                stackLayout.Children.Add(frame);
                //grade = student.Grade ;
            }
            else
            {

                entry1.FontSize = 15;
                entry1.HorizontalOptions = LayoutOptions.FillAndExpand;
                
                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Content = entry1,
                };
                stackLayout.Children.Add(frame);
                //temp.Grade = Convert.ToInt32(entry.Text);
            }

            

            Label label3 = new Label()
            {
                Text = "Email: " ,
                FontSize = 15,
            };
            stackLayout.Children.Add(label3);
            Entry entry2 = new Entry();
            if (student.Email != null)
            {

                entry2.Text = student.Email;
                entry2.FontSize = 15;
                entry2.HorizontalOptions = LayoutOptions.FillAndExpand;
                
                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Content = entry2,
                };
                stackLayout.Children.Add(frame);
                //email = entry2.Text;
            }
            else
            {

                entry2.FontSize = 15;
                entry2.HorizontalOptions = LayoutOptions.FillAndExpand;
                
                Frame frame = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Content = entry2,
                };
                stackLayout.Children.Add(frame);
                //temp.Email = entry.Text;
            }

            

            Label label5 = new Label()
            {
                Text = "Số điện thoại: " + student.Phone,
                FontSize = 15,
            };
            stackLayout.Children.Add(label5);
            Entry entry3 = new Entry();
            if (student.Phone != 0)
            {

                entry3.Text = student.Phone.ToString();
                entry3.FontSize = 15;
                entry3.HorizontalOptions = LayoutOptions.FillAndExpand;
                
                Frame frame1 = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Content = entry3,
                };
                stackLayout.Children.Add(frame1);
                //phone = student.Phone;
            }
            else
            {

                entry3.FontSize = 15;
                entry3.HorizontalOptions = LayoutOptions.FillAndExpand;
                
                Frame frame1 = new Frame()
                {
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Content = entry3,
                };
                stackLayout.Children.Add(frame1);
                //temp.Phone = Convert.ToInt32(entry.Text);
            }


            Account account = new Account()
            {
                Username = student.Account.Username,
                Password = student.Account.Password,
            };
            temp.Account = account;
            
            scroll.Content = stackLayout;
            Button button1 = new Button()
            {
                Text = "Save!",
                FontSize = 12,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            button1.Clicked += (object sender, EventArgs e) => Button1_Clicked(sender, e, student, temp, entry, checkBox1, checkBox2, entry1, entry2, entry3);
            layout.Children.Add(scroll);
            layout.Children.Add(button1);
        }

        private void Button1_Clicked(object sender, EventArgs e, Student student, Student temp, Entry name, CheckBox male, CheckBox female, Entry grade, Entry email, Entry phone)
        {
            temp.Name = name.Text;
            temp.Grade = Convert.ToInt32(grade.Text);
            temp.Phone = Convert.ToInt32(phone.Text);
            temp.Email = email.Text;
            if (male.IsChecked)
            {
                temp.isMale = true;
            }else if(female.IsChecked)
            {
                temp.isMale = false;
            }
            HttpClient client = new HttpClient();
            string ri = "https://physicwmp.herokuapp.com/api/students/" + student.Account.Username;
            Uri uri = new Uri(ri);
            var delete = client.DeleteAsync(uri);
            delete.Wait();
            var create = client.PostAsJsonAsync<Student>("https://physicwmp.herokuapp.com/api/students/", temp);
            create.Wait();
            this.DisplayAlert("Notification", "Update Successfully", "Ok!");
            this.Navigation.PopModalAsync();
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
    }
}