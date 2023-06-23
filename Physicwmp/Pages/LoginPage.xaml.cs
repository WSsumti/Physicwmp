using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Driver;
using MongoDB.Bson;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using Physicwmp.Data;
using System.Threading;
using Physicwmp;

namespace Physicwmp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public static HttpClient client = new HttpClient();
        private static Student student = new Student();
        private static Teacher teacher = new Teacher();
        private static string user;
        private static string pass;
        public LoginPage()
        {
            InitializeComponent();
            checkbox.IsChecked = false;
        }

        public void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (checkbox.IsChecked == false)
            {
                user = Username.Text;
                pass = Password.Text;
                //ThreadStart ts = new ThreadStart(LoginAuthenticator);
                //Thread thr = new Thread(ts);
                //thr.Start();
                try
                {
                    if (student.Account.Password == pass)
                    {
                        App.student = student;
                        this.Navigation.PushModalAsync(new Main
                        {
                        });
                    }
                    else
                    {
                        this.DisplayAlert("Warning", "Wrong Username or Password", "Ok");
                    }

                }
                catch (Exception)
                {
                    this.DisplayAlert("Warning", "Wrong Username or Password", "Ok");

                }
            }
            else
            {
                //var t = Thread.CurrentThread;
                user = Username.Text;
                pass = Password.Text;
                ////ThreadStart ts = new ThreadStart(TeacherAuthenticator);
                //Thread thr = new Thread(new ThreadStart(TeacherAuthenticator));
                //thr.Start();
                //t.IsBackground = false;
                //thr.IsBackground = true;

                TeacherAuthenticator();
                try
                {
                    if (teacher.Account.Password == pass)
                    {
                        App.teacher = teacher;
                        this.Navigation.PushModalAsync(new TabbedTeacher());
                    }
                    else
                    {
                        this.DisplayAlert("Warning", "Wrong Username or Password", "Ok");
                    }
                //thr.IsBackground = false;
                //t.IsBackground = true;
            }
                catch (Exception)
            {
                this.DisplayAlert("Warning", "Wrong Username or Password", "Ok");
            }
        }


        }
        public async void LoginAuthenticator()
        {
            Uri uri = new Uri("https://physicwmp.herokuapp.com/api/students/" + user);
            var rep = await client.GetStringAsync(uri).ConfigureAwait(false);
            //string content = await rep.Content.ReadAsStringAsync();
            student = JsonConvert.DeserializeObject<Student>(rep);
        }
        public async void TeacherAuthenticator()
        {
            Uri uri = new Uri("https://physicwmp.herokuapp.com/api/teachers/" + user);
            var rep = await client.GetStringAsync(uri).ConfigureAwait(false);
            teacher = JsonConvert.DeserializeObject<Teacher>(rep);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if (checkbox.IsChecked)
            {
                checkbox.IsChecked = false;
            }
            else
            {
                checkbox.IsChecked = true;
            }
        }
    }
}