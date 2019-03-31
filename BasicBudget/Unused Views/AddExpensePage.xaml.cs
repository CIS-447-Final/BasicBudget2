using System;
using System.Collections.Generic;
using BasicBudget.Models;
using BasicBudget.Models.OCR;

using Xamarin.Forms;

namespace BasicBudget
{
    public partial class AddExpensePage : ContentPage
    {
        Category categoryName;

        public AddExpensePage(Category category)
        {
            InitializeComponent();

            //CameraButton.Clicked += CameraButton_Clicked;

            categoryName = category;
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            AddExpense();
            Navigation.PopAsync();
        }

        public void AddExpense()
        {

            if(!string.IsNullOrEmpty(ExpenseName.Text) && !string.IsNullOrEmpty(ExpenseTotal.Text))
            {
          
                MonthBudget currentMonthBudget = Manager.GetSelectedMonthBudget();

                currentMonthBudget.AddExpenseToCategory(categoryName.Name, ExpenseName.Text, DateTime.Now, decimal.Parse(ExpenseTotal.Text));
            }

        }


        //private async void CameraButton_Clicked(object sender, EventArgs e)
        //{
        //    var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { CompressionQuality = 80});

        //    if(photo != null)
        //    {
        //        decimal receiptTotal = OCRProgram.TextExtraction(photo.GetStream());

        //        // Sets the Expense text field to the total grabbed by the OCR
        //        ExpenseTotal.Text = receiptTotal.ToString();
        //    }

        //}
    }
}
