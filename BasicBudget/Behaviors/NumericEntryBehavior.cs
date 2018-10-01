using System;
using Xamarin.Forms;

namespace BasicBudget.Behaviors
{
    /// <summary>
    /// Makes sure that the user enters in a number.
    /// </summary>
    public class NumericEntryBehavior: Behavior<Entry>
    {
        // User Clicks into text box.
        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += TextChanged_Handler;
        }

        // Handles the Text input.
        void TextChanged_Handler(object sender, TextChangedEventArgs e)
        {
            // Checks if string is empy.
            if (string.IsNullOrEmpty(e.NewTextValue))
                return;

            // Check if string is a double.
            double _;
            if (!double.TryParse(e.NewTextValue, out _))
                ((Entry)sender).Text = e.OldTextValue;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= TextChanged_Handler;
        }

    }
}
