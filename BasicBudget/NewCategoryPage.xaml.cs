using System;
using System.Collections.Generic;
using BasicBudget.TestData;

using Xamarin.Forms;

namespace BasicBudget
{
    public partial class NewCategoryPage : ContentPage
    {
        public NewCategoryPage()
        {
            InitializeComponent();
           
        }

        // Done Button.
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            AddNewCategory();

            Navigation.PopAsync();
            //Navigation.PushAsync(new CategoryPage());
        }

        void AddNewCategory()
        {
            Models.Category testCategory = new Models.Category();
            testCategory.Budget = float.Parse(CategoryExpense.Text);
            testCategory.Name = CategoryName.Text;
            CategoryData.Categories.Add(testCategory);

            CategoryPage.UpdateCategoryList();
            //page.UpdateCategoryList(_context);
        }
    }
}
