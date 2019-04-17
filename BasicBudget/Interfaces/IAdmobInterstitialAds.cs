using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BasicBudget.Interfaces
{
    public interface IAdmobInterstitialAds
    {
        Task LoadAd(string adId);
        void DisplayAd();
    }
}
