using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace BasicBudget
{
    public partial class HomePageOne : TabbedPage
    {
        public HomePageOne()
        {
            InitializeComponent();

        }

      
        public static void ChangeTitle()
        {
            HomePageOne test = new HomePageOne();
            test.Title = "Hello";
        }
    }
}
