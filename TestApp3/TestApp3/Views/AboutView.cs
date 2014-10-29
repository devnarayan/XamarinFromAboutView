using System;
using TestApp3.Models;
using Xamarin.Forms;

namespace TestApp3
{
	public class AboutView : BaseView
	{
		public AboutView ()
		{
            Title = "About Me(DEV)";
           
			var stack = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Spacing = 10
			};

			var image = new Image ();
			image.Source = ImageSource.FromFile ("scott.jpg");
			image.Aspect = Aspect.AspectFill;

			stack.Children.Add (image);

			var stack2 = new StackLayout {
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Spacing = 10,
				Padding = 10
			};

			var about = new Label {
				Font = Font.SystemFontOfSize (NamedSize.Medium),
				Text = "My name is Dev. I'm a programmer, teacher, and speaker. I work out of my home office in Portland, Oregon for the Web Platform Team at Microsoft, but this blog, its content and opinions are my own. I blog about technology, culture, gadgets, diversity, code, the web, where we're going and where we've been. I'm excited about community, social equity, media, entrepreneurship and above all, the open web.",
				LineBreakMode = LineBreakMode.WordWrap
			};

        
			stack2.Children.Add(about);

			var findMe = new Label {
				Font = Font.BoldSystemFontOfSize (NamedSize.Medium),
				Text = "Find Me", 
				LineBreakMode = LineBreakMode.NoWrap
			};

			stack2.Children.Add(findMe);



			var twitter = new Image {
				Source = new FileImageSource { File = "twitter.png"}
			};
			twitter.GestureRecognizers.Add (new TapGestureRecognizer ((view, args) =>{
				this.Navigation.PushAsync(new WebsiteView("http://m.twitter.com/devnagar29", "@devnagar29"));
			}));

			var facebook = new Image {
				Source = new FileImageSource { File = "facebook.png"}
			};
			facebook.GestureRecognizers.Add (new TapGestureRecognizer ((view, args) =>{
				this.Navigation.PushAsync(new WebsiteView("http://facebook.com/devnagar", "devnagar @Facebook"));
			}));

            //var instagram = new Image {
            //    Source = new FileImageSource { File = "instagram.png"}
            //};
            //instagram.GestureRecognizers.Add (new TapGestureRecognizer ((view, args) =>{
            //    this.Navigation.PushAsync(new WebsiteView("http://instagram.com/shanselman", "Scott @Instagram"));
            //}));

			var google = new Image();
            google.Source = ImageSource.FromFile("googleplus.png");
            google.Aspect = Aspect.AspectFill;

			google.GestureRecognizers.Add (new TapGestureRecognizer ((view, args) =>{
                this.Navigation.PushAsync(new WebsiteView("https://plus.google.com/+DevnarayanNagar", "DevNagar+"));
			}));

			var socialStack = new StackLayout {
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				Orientation = StackOrientation.Horizontal,
				Spacing = 20,
				Children = {twitter, facebook, google}
			};

			stack2.Children.Add (socialStack);

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
            stack2.Children.Add(listView);

			stack.Children.Add (new ScrollView{VerticalOptions = LayoutOptions.End, Content = stack2 });

			Content = stack;
		}
	}
}

