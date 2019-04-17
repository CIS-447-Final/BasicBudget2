using System;
using System.Collections.Generic;
using System.Text;

namespace BasicBudget.Interfaces
{
    public enum ScreenName { CategoryPage, ExpensePage}
    public interface IAnalyticsManager
    {
        IAnalyticsManager InitWithId(string analyticsId);
        void TrackScreen(ScreenName screen);
    }
}
