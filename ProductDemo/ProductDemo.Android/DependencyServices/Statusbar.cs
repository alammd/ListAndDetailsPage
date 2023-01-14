using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ProductDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using static ProductDemo.Droid.Resource;
using ProductDemo.Droid.DependencyServices;

[assembly: Dependency(typeof(Statusbar))]
namespace ProductDemo.Droid.DependencyServices
{
    public class Statusbar : FormsAppCompatActivity, IStatusBarPlatformSpecific
    {
        public void SetStatusBarColor(Xamarin.Forms.Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var androidColor = color.ToAndroid();
                Xamarin.Essentials.Platform.CurrentActivity.Window.SetStatusBarColor(androidColor);
            }
        }
    }
}