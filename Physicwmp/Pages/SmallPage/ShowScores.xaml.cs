using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Physicwmp.Pages.SmallPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShowScores : ContentPage
    {
        public ShowScores(StackLayout layout)
        {
            InitializeComponent();
            UI(layout);
        }
        public void UI(StackLayout layout)
        {
            Label label = new Label()
            {
                Text = "Lịch sử làm bài: ",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };
            layout.Children.Add(label);
            ScrollView scroll = new ScrollView();
            StackLayout stack = new StackLayout();
            foreach (var q in App.student.Test)
            {
                StackLayout stackLayout = new StackLayout();
                Label label1 = new Label()
                {
                    Text = "Tên bài tập: " + q.NameTest,
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                stackLayout.Children.Add(label1);
                Label label2 = new Label()
                {
                    Text = "Số câu đúng: " + q.RightAns.ToString() + "/" + q.SumofQuestion.ToString(),
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                stackLayout.Children.Add(label2);
                Label label3 = new Label()
                {
                    Text = "Thời gian bắt đầu: " + q.TimeStart,
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                stackLayout.Children.Add(label3);
                Label label4 = new Label()
                {
                    Text = "Thời gian kết thúc: " + q.TimeEnd,
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                stackLayout.Children.Add(label4);
                Label label5 = new Label()
                {
                    Text = "Điểm: " + q.Score.ToString(),
                    FontSize = 12,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                };
                stackLayout.Children.Add(label5);
                Frame frame = new Frame()
                {
                    Content = stackLayout,
                    BorderColor = Color.Black,
                    CornerRadius = 5,
                };
                stack.Children.Add(frame);
            }
            Button back = new Button()
            {
                Text = "Back",
                FontSize = 13,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };
            back.Clicked += Back_Clicked;
            stack.Children.Add(back);
            scroll.Content = stack;

            layout.Children.Add(scroll);
        }

        private void Back_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PopModalAsync();
        }
    }
}