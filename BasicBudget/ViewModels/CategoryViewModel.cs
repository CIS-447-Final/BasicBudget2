using System;
using BasicBudget.Models;
using BasicBudget.TestData;
using System.Linq;
using System.ComponentModel;
using System.Collections.ObjectModel;


namespace BasicBudget.ViewModels
{
    public class CategoryViewModel
    {
        private ObservableCollection<Category> categories;

        public ObservableCollection<Category> Categories
        {
            get { return categories; }
            set
            {
                categories = value;

            }
        }

        public CategoryViewModel()
        {
            Categories = new ObservableCollection<Category>();

            CategoryData _context = new CategoryData();

            //foreach(var category in _context.Categories)
            //{
            //    //Categories.Add(category);
            //}

        }
    }
}
