using BasicBudget.Models;
using BasicBudget.TestData;
using System.Collections.ObjectModel;
using Xamarin.Forms;



namespace BasicBudget
{
    public partial class CategoryPage : ContentPage
    {
        private static ObservableCollection<Category> categories { get; set; }

        public CategoryPage()
        {

            categories = new ObservableCollection<Category>();
            InitializeComponent();
            categoryListView.ItemsSource = categories;

            AddData();
            Test.Text = categories.Count.ToString();
        }

       

        void AddData()
        {
            //CategoryData _context = new CategoryData();

            foreach(var category in CategoryData.Categories)
            {
                categories.Add(category);
            }
        }

        public static void UpdateCategoryList()
        {
            int lengthOfList = CategoryData.Categories.Count;

            categories.Add(CategoryData.Categories[lengthOfList - 1]);

        }

        // Category clicked.
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedCategory = e.SelectedItem as Category;
            Navigation.PushAsync(new CategoryDetailPage(selectedCategory));
        }



        // New Category button cliked
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewCategoryPage());
        }
    }
}
