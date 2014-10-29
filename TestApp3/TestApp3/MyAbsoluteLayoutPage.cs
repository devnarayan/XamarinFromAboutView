using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp3
{
   public class MyAbsoluteLayoutPage:ContentPage
    {
       public MyAbsoluteLayoutPage(string title)
       {
           Title = title;
           var red = new Label
           {
               Text = "Stop",
               BackgroundColor = Color.Red,
               Font = Font.SystemFontOfSize(20),
               WidthRequest = 200,
               HeightRequest = 30
           };
           var yellow = new Label
           {
               Text = "Slow down",
               BackgroundColor = Color.Yellow,
               Font = Font.SystemFontOfSize(20),
               WidthRequest = 160,
               HeightRequest = 160
           };
           var green = new Label
           {
               Text = "Go",
               BackgroundColor = Color.Green,
               Font = Font.SystemFontOfSize(20),
               WidthRequest = 50,
               HeightRequest = 50

           };
           var absLayout = new AbsoluteLayout();
           absLayout.Children.Add(red, new Point(20, 20));
           absLayout.Children.Add(yellow, new Point(40, 60));
           absLayout.Children.Add(green, new Point(80, 180));

           Content = absLayout;
       }
    }
}
