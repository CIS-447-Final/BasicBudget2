using System;
using BasicBudget;
using BasicBudget.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(NavBarRenderer))]
namespace BasicBudget.iOS
{
    public class NavBarRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            NavigationBar.PrefersLargeTitles = true;

            //if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
            //{
            //    NavigationBar.PrefersLargeTitles = true;
            //}

         }

    }
}
