using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physicwmp.Pages.SmallPage.ForDocs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeworkAnswer : ContentPage
    {
        private List<Entry> an = new List<Entry>();
        public List<char> a = new List<char>();
        public HomeworkAnswer()
        {

        }
        public HomeworkAnswer(StackLayout layout, int n)
        {
            InitializeComponent();
            UI(layout, n);
        }

        public void UI(StackLayout layout, int n)
        {
            Button close = new Button()
            {
                Text = "Close",
                FontSize = 13,
            };
            close.Clicked += Close_Clicked;
            layout.Children.Add(close);
            StackLayout stack = new StackLayout();
            Label label = new Label()
            {
                Text = "Đáp án",
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                FontSize = 15,
            };
            layout.Children.Add(label);
            for (int i = 1; i <= n; ++i)
            {
                Grid grid = new Grid()
                {
                    ColumnDefinitions = 
                    {
                        new ColumnDefinition
                        {
                            Width = new GridLength(0.33333,GridUnitType.Star)
                        },
                        new ColumnDefinition
                        {
                            Width = new GridLength(0.76666,GridUnitType.Star)
                        }
                    }
                };
                Label label1 = new Label()
                {
                    Text = "Câu " + i.ToString(),
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                Entry entry = new Entry()
                {
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                an.Add(entry);
                Grid.SetColumn(label1, 0);
                Grid.SetColumn(entry, 1);
                grid.Children.Add(label1);
                grid.Children.Add(entry);
                stack.Children.Add(grid);
            }
            Button button = new Button()
            {
                Text = "Ok",
                FontSize = 12,
            };
            button.Clicked += Button_Clicked;
            stack.Children.Add(button);
            ScrollView scroll = new ScrollView();
            scroll.Content = stack;
            layout.Children.Add(scroll);
        }

        private void Close_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            bool flag = false;
            foreach (var item in an)
            {
                if (item.Text == null)
                {
                    flag = true;
                    a.Clear();
                    break;
                }
                else
                {
                    var x = item.Text.ToCharArray();
                    a.Add(x[0]);
                }
            }
            if (flag == false)
                this.Navigation.PopModalAsync();
            else
                this.DisplayAlert("Notification:", "Nhập thiếu dữ liệu!", "Ok");
        }
    }
}