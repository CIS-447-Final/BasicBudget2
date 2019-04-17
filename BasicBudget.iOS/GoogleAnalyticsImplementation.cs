using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicBudget.Interfaces;
using Foundation;
using Google.Analytics;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(BasicBudget.iOS.GoogleAnalyticsImplementation))]
namespace BasicBudget.iOS
{
    public class GoogleAnalyticsImplementation : IAnalyticsManager
    {
        private static Gai gaInstance;
        private static ITracker tracker;

        public IAnalyticsManager InitWithId(string analyiticsId)
        {
            gaInstance = Gai.SharedInstance;
            gaInstance.DispatchInterval = 10;
            gaInstance.TrackUncaughtExceptions = true;
            tracker = gaInstance.GetTracker(analyiticsId);

            return this;
        }

        public void TrackScreen(ScreenName screen)
        {
            tracker.Set(GaiConstants.ScreenName, screen.ToString());
            tracker.Send(DictionaryBuilder.CreateScreenView().Build());
            gaInstance.Dispatch();
        }
    }
}