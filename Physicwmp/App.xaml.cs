using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Physicwmp.Pages;
using MongoDB.Driver;
using Physicwmp.Data;

namespace Physicwmp
{
    public partial class App : Application
    {
        public static Student student { get; set; }
        public static Teacher teacher { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage(new LoginPage()); 
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
