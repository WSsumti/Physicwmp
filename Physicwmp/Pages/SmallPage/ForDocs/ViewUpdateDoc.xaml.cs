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
    public partial class ViewUpdateDoc : ContentPage
    {
        public ViewUpdateDoc(StackLayout layout, HomeworkModel hw)
        {
            InitializeComponent();
            UI(layout, hw);
        }
        public void UI(StackLayout layout, HomeworkModel hw)
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
                    Text = "Tên bài tập: " + hw.Name,
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
                    Text = "Link: " + hw.URL,
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
                Label deadl = new Label()
                {
                    Text = "Thời gian cuối cùng được truy cập: " + hw.Deadline.ToString(),
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                Frame deadlfr = new Frame()
                {
                    Content = deadl,
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                };
                stack.Children.Add(deadlfr);
                Button ans = new Button()
                {
                    Text = "Show answers",
                    FontSize = 13,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                ans.Clicked += (object sender, EventArgs e) => Ans_Clicked(sender,e,hw.Answer);
                stack.Children.Add(ans);
                scroll.Content = stack;
                layout.Children.Add(scroll);
            
            
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }

        private void Ans_Clicked(object sender, EventArgs e, List<char> ans)
        {
            StackLayout layout = new StackLayout()
            {
                WidthRequest = 350,
                HeightRequest = 450,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            Button back = new Button()
            {
                Text = "Back",
                FontSize = 13,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };
            back.Clicked += Back_Clicked;
            int i = 0;
            ScrollView scroll = new ScrollView();
            StackLayout stack = new StackLayout();
            foreach (var an in ans)
            {
                ++i;
                Label label = new Label()
                {
                    Text = "Câu " + i.ToString() + ": " + an,
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                stack.Children.Add(label);
            }
            scroll.Content = stack;
            layout.Children.Add(scroll);
            this.Navigation.PushModalAsync(new ContentPage()
            {
                Content = layout,
                BackgroundColor = Color.White,
            });
        }

    }
}