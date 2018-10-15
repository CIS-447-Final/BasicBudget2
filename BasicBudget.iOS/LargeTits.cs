using Foundation;
using System;
using UIKit;
namespace BasicBudget.iOS
{
    public class LargeTits: UINavigationController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            NavigationBar.PrefersLargeTitles = true;
        }
    }
}
