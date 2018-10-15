using System;
using System.Collections.Generic;



using Xamarin.Forms;

namespace BasicBudget
{
    public partial class LargeTitleSample : ContentPage
    {

        public List<string> Items => new List<string>()
        {
            "a",
            "b",
            "c",
            "d",
            "e",
            "f",
            "g",
            "h",
            "i",
            "j",
            "k",
            "l",
            "m",
            "n",
            "o",
            "p",
            "q",
            "r",
            "s",
            "t",
            "u",
            "v",
            "w",
            "x",
            "y",
            "z"
        };

        public LargeTitleSample()
        {
            InitializeComponent();

            BindingContext = this;

        }
    }
}
