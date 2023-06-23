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
    public partial class Homework : ContentPage
    {
        public Homework()
        {
            InitializeComponent();
            
            ShowAllHomework();
            
        }
 
        private void Bt_Clicked(object sender, EventArgs e, string url, List<char> an, HomeworkModel hw)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            this.Navigation.PushModalAsync(new DoingHw(url, an, hw, dt));
        }

        public async void ShowAllHomework()
        {
            Services ser = new Services();
            var homeworks = await ser.GetAllHomeworks(App.student.Grade);
            foreach (var hw in homeworks.Reverse<HomeworkModel>())
            {
                Button bt = new Button()
                {
                    Text = "Lam bai!"
                };
                bt.Clicked += (object sender, EventArgs e) => Bt_Clicked(sender, e, hw.URL, hw.Answer, hw);
                HomeworkPost.PostHomework(layout, hw.Name, bt, hw.URL);
            }
        }
    }
}