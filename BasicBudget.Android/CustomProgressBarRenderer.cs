using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BasicBudget.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using BasicBudget.Controls;

[assembly: ExportRenderer(typeof(CustomProgressBarControl), typeof(CustomProgressBarRenderer))]
namespace BasicBudget.Droid
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        // IDK what this does, just wrote it so that the class wouldn't be obsolete
        public CustomProgressBarRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e)
        {
            base.OnElementChanged(e);

            var height = App.ScreenHeight;
            var y = 5;

            //Control.ProgressTintList = Android.Content.Res.ColorStateList.ValueOf(Color.Green.ToAndroid());
            Control.ScaleY = y; //Changes the height
        }
    }
}