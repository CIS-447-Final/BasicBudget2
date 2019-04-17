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
using BasicBudget.Interfaces;
using BasicBudget.Droid;
using Xamarin.Forms;
using Google.Ads;
using System.Threading.Tasks;
using Android.Gms.Ads;

[assembly: Dependency(typeof(AdmobInterstitial))]
namespace BasicBudget.Droid
{
    public class AdmobInterstitial : IAdmobInterstitialAds
    {
        private InterstitialAd AdInterstitial;

        public Task LoadAd(string adId)
        {
            var displayTask = new TaskCompletionSource<bool>();
            AdInterstitial = new InterstitialAd(context: Android.App.Application.Context)
            {
                AdUnitId = adId
            };
            {
                var adInterstitialListener = new AdInterstitialListener(AdInterstitial)
                {
                    AdClosed = () =>
                    {
                        if (displayTask != null)
                        {
                            displayTask.TrySetResult(AdInterstitial.IsLoaded);
                            displayTask = null;
                        }
                    },
                    AdFailed = () =>
                    {
                        if (displayTask != null)
                        {
                            displayTask.TrySetResult(AdInterstitial.IsLoaded);
                            displayTask = null;
                        }
                    }
                };

                //Android.Gms.Ads.AdRequest.Builder requestBuilder = new Android.Gms.Ads.AdRequest.Builder();
                AdInterstitial.AdListener = adInterstitialListener;
                //AdInterstitial.LoadAd(requestBuilder.Build());
            }

            return Task.WhenAll(displayTask.Task);
        }

        public void DisplayAd()
        {
            Android.Gms.Ads.AdRequest.Builder requestBuilder = new Android.Gms.Ads.AdRequest.Builder();
            AdInterstitial.LoadAd(requestBuilder.Build());
        }


        public class AdInterstitialListener : AdListener
        {
            private readonly InterstitialAd _interstitialAd;

            public AdInterstitialListener(InterstitialAd interstitialAd)
            {
                _interstitialAd = interstitialAd;
            }

            public Action AdLoaded { get; set; }
            public Action AdClosed { get; set; }
            public Action AdFailed { get; set; }

            public override void OnAdLoaded()
            {
                base.OnAdLoaded();

                if (_interstitialAd.IsLoaded)
                {
                    _interstitialAd.Show();
                }
                AdLoaded?.Invoke();
            }

            public override void OnAdClosed()
            {
                base.OnAdClosed();
                AdClosed?.Invoke();
            }

            public override void OnAdFailedToLoad(int errorCode)
            {
                base.OnAdFailedToLoad(errorCode);
                AdFailed?.Invoke();
            }
        }


    }
}