using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using BasicBudget.Interfaces;
using System.Threading.Tasks;
using Google.MobileAds;
using Xamarin.Forms;
using BasicBudget.iOS;

[assembly: Dependency(typeof(AdmobInterstitial))]
namespace BasicBudget.iOS
{
    public class AdmobInterstitial : IAdmobInterstitialAds
    {
        private Interstitial interstitial;
        public Task LoadAd(string adId)
        {
            TaskCompletionSource<bool> displayAdTask = new TaskCompletionSource<bool>();
            interstitial = new Interstitial(adId);

            interstitial.AdReceived += (sender, args) =>
            {
                if (interstitial.IsReady)
                {
                    var keyWindow = UIApplication.SharedApplication.KeyWindow;
                    var rootViewController = keyWindow.RootViewController;
                    while (rootViewController.PresentedViewController != null)
                    {
                        rootViewController = rootViewController.PresentedViewController;
                    }
                    interstitial.PresentFromRootViewController(rootViewController);
                }
            };

            interstitial.ScreenDismissed += (sender, e) =>
            {
                if (displayAdTask != null)
                {
                    displayAdTask.TrySetResult(interstitial.IsReady);
                    displayAdTask = null;
                }
            };

            interstitial.ReceiveAdFailed += (sender, e) =>
            {
                displayAdTask.TrySetResult(false);
                displayAdTask.TrySetCanceled();
                displayAdTask = null;
            };

            //var request = Request.GetDefaultRequest();
            //interstitial.LoadRequest(request);
            return Task.WhenAll(displayAdTask.Task);
        }

        public void DisplayAd()
        {
            var request = Request.GetDefaultRequest();
            interstitial.LoadRequest(request);
        }
    }
}