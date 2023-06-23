using Physicwmp.Data;
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
    public partial class ViewDoc : ContentPage
    {
        public ViewDoc(StackLayout layout, Document dcm)
        {
            InitializeComponent();
            UI(layout, dcm);
        }
        public void UI(StackLayout layout, Document dcm)
        {
            ScrollView scroll = new ScrollView();
            StackLayout stack = new StackLayout();
            Button back = new Button()
            {
                Text = "Back",
                FontSize = 13,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            back.Clicked += Back_Clicked;
            layout.Children.Add(back);

            Label title = new Label()
            {
                Text = "View",
                FontSize = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };
            layout.Children.Add(title);

            Label name = new Label()
            {
                Text = "Tên bài tập: " + dcm.Name,
                FontSize = 12,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            Frame namefr = new Frame()
            {
                BorderColor = Color.Black,
                CornerRadius = 5,
                Content = name,
            };
            stack.Children.Add(namefr);


            Label url = new Label()
            {
                Text = "Link: " + dcm.URL,
                FontSize = 12,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            Frame urlname = new Frame()
            {
                Content = url,
                BorderColor = Color.Black,
                CornerRadius = 5,
            };
            stack.Children.Add(urlname);

            CheckBox cb1 = new CheckBox();
            CheckBox cb2 = new CheckBox();
            if (dcm.IsVideo)
            {
                cb1.IsChecked = true;
                cb2.IsChecked = false;
            }
            else
            {
                cb2.IsChecked = true;
                cb1.IsChecked = false;
            }
            cb1.IsEnabled = false;
            cb2.IsEnabled = false;
            Label isVideo = new Label()
            {
                Text = "Video",
                FontSize = 12,
                HorizontalOptions = LayoutOptions.End,
            };
            Label isDocument = new Label()
            {
                Text = "Document",
                FontSize = 12,
                HorizontalOptions = LayoutOptions.End,
            };
            Grid.SetColumn(cb1, 0);
            Grid.SetColumn(cb2, 1);
            Grid.SetColumn(isVideo, 0);
            Grid.SetColumn(isDocument, 1);
            Grid grid = new Grid()
            {
                ColumnDefinitions =
                    {
                        new ColumnDefinition()
                        {
                            Width = new GridLength(0.5,GridUnitType.Star),
                        },
                        new ColumnDefinition()
                        {
                            Width = new GridLength(0.5,GridUnitType.Star),
                        },
                    },
                Children =
                    {
                        cb1,
                        isVideo,
                        cb2,
                        isDocument,
                    },
            };
            stack.Children.Add(grid);
            
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}