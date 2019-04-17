using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicBudget.iOS;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using BasicBudget.Controls;

[assembly: ExportRenderer(typeof(CustomProgressBarControl), typeof(CustomProgressBarRenderer))]
namespace BasicBudget.iOS
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            var height = App.ScreenHeight;

            var x = 1.0f;
            var y = 7.0f;

            
            CGAffineTransform transform = CGAffineTransform.MakeScale(x, y);
            this.Transform = transform;
            //Rounds the progressbar
            //this.ClipsToBounds = true;
            //this.Layer.MasksToBounds = true;
            //this.Layer.CornerRadius = 5;
        }
    }
}