using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Physicwmp.Pages;

namespace Physicwmp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : TabbedPage
    {
        public Main()
        {
            InitializeComponent();
            Homepage hp = new Homepage()
            {
                Title = "HomePage"
            };
            OnClass ol = new OnClass()
            {
                Title = "OnClass"
            };
            Homework hw = new Homework()
            {
                Title = "HomeWork"
            };
            Info i4 = new Info()
            {
                Title = "Info"
            };
            this.Children.Add(hp);
            this.Children.Add(ol);
            this.Children.Add(hw);
            this.Children.Add(i4);

        }
    }
}