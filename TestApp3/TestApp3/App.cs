using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestApp3.Models;
using Xamarin.Forms;

namespace TestApp3
{
    public class App
    {
        public static Page GetAboutPage()
        {
            return new NavigationPage(new AboutView());
        }
        public static Page GetHomePage()
        {
            return new NavigationPage(new HomeMasterView(new HomeViewModel()));
        }
        public static Page GetMainPage()
        {
            var red = new Label
            {
                Text = "Stop",
                BackgroundColor = Color.Red,
                Font = Font.SystemFontOfSize(20),
                WidthRequest = 100
            };
            var yellow = new Label
            {
                Text = "Slow down",
                BackgroundColor = Color.Yellow,
                Font = Font.SystemFontOfSize(20),
                WidthRequest = 100
            };
            var green = new Label
            {
                Text = "Go",
                BackgroundColor = Color.Green,
                Font = Font.SystemFontOfSize(20),
                WidthRequest = 200
            };
            var listView = new ListView
            {
                RowHeight = 30
            };
            
            listView.ItemsSource = new TodoItem[] {
    new TodoItem {Name = "Buy pears"},
    new TodoItem {Name = "Buy oranges", Done=true},
    new TodoItem {Name = "Buy mangos"},
    new TodoItem {Name = "Buy apples", Done=true},
    new TodoItem {Name = "Buy bananas", Done=true}
};
            listView.ItemTemplate = new DataTemplate(typeof(TextCell));
            listView.ItemTemplate.SetBinding(TextCell.TextProperty, "Name");
            listView.ItemSelected += async (sender, e) =>
            {
                var todoItem = (TodoItem)e.SelectedItem;
                var todoPage = new MyAbsoluteLayoutPage(todoItem.Name); // so the new page shows correct data
                await listView.Navigation.PushAsync(todoPage);
            };
            return new ContentPage
            {
                Content = new StackLayout
            {
                Spacing = 10,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.Start,
                Children = { red, yellow, green, listView }
            },
            };
        }
    }
}