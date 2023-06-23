using Physicwmp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physicwmp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public static List<Notification> notifications { get; set; }
        public Homepage()
        {
            InitializeComponent();
            ShowAllPost();
        }
        public async void ShowAllPost()
        {
            Services ser = new Services();
            notifications = await ser.GetAllNotification(App.student.Grade);
            foreach (var notification in notifications.Reverse<Notification>())
            {
                PostStatus.CreatePost(layout, notification.TeacherName, notification.Content, notification.TimeUpload);
            }
        }
    }
}