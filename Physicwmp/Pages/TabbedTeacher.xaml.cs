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
    public partial class TabbedTeacher : TabbedPage
    {
        public TabbedTeacher()
        {
            InitializeComponent();
            TeacherHomepage hp = new TeacherHomepage()
            {
                Title = "Homepage"
            };
            UpdateStudent us = new UpdateStudent()
            {
                Title = "Class List"
            };
            UploadHWorOnclass up = new UploadHWorOnclass()
            {
                Title = "Upload Docs"
            };
            this.Children.Add(hp);
            this.Children.Add(us);
            this.Children.Add(up);
        }
    }
}