using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Gms.Analytics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BasicBudget.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(BasicBudget.Droid.GoogleAnalyticsImplementation))]
namespace BasicBudget.Droid
{
    public class GoogleAnalyticsImplementation : IAnalyticsManager
    {
        private static GoogleAnalytics gaInstance;
        private static Tracker tracker;

        public IAnalyticsManager InitWithId(string analyiticsId)
        {
            gaInstance = GoogleAnalytics.GetInstance(Android.App.Application.Context);
            gaInstance.SetLocalDispatchPeriod(10);
            tracker = gaInstance.NewTracker(analyiticsId);
            return this;
        }

        public void TrackScreen(ScreenName screen)
        {
            tracker.SetScreenName(screen.ToString());
            var builder = new HitBuilders.ScreenViewBuilder();
            tracker.Send(builder.Build());
            gaInstance.DispatchLocalHits();
        }
    }
}