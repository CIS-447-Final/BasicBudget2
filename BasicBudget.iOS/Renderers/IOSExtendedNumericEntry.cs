using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using BasicBudget.Controls;
using Xamarin.Forms.Platform.iOS;
using BasicBudget.iOS.Renderers;
using System.Drawing;

[assembly: ExportRenderer(typeof(ExtendedNumericEntry), typeof(IOSExtendedNumericEntry))]
namespace BasicBudget.iOS.Renderers
{
    public class IOSExtendedNumericEntry : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            var toolbar = new UIToolbar(new RectangleF(0.0f, 0.0f, (float)Control.Frame.Size.Width, 44.0f));

            toolbar.Items = new[]
            {
                new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace),
                new UIBarButtonItem(UIBarButtonSystemItem.Done, delegate { Control.ResignFirstResponder(); })
            };

            this.Control.InputAccessoryView = toolbar;
        }
    }
}