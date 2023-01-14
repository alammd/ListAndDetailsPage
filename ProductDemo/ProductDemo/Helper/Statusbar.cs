using ProductDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ProductDemo.Helper
{
    public class Statusbar
    {
        public static void SetStatusbarAndNavigationBarColor(string colorA, string ColorB)
        {
            var navigationPage = Application.Current.MainPage as NavigationPage;
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.StartPoint = new Point(0, 1);
            linearGradientBrush.EndPoint = new Point(1, 0);

            linearGradientBrush.GradientStops = new GradientStopCollection()
            {
                new GradientStop(){Color = Color.FromHex(colorA), Offset=0.1f},
                new GradientStop(){Color = Color.FromHex(ColorB), Offset=1.0f},
            };
            navigationPage.BarBackground = linearGradientBrush;
            DependencyService.Get<IStatusBarPlatformSpecific>().SetStatusBarColor(Color.FromHex(colorA));
        }
    }
}
