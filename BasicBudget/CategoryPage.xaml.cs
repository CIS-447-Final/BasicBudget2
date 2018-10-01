using BasicBudget.Models;
using BasicBudget.TestData;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace BasicBudget
{
    public partial class CategoryPage : ContentPage
    {
        private ObservableCollection<Category> categories { get; set; }

        public CategoryPage()
        {
            categories = new ObservableCollection<Category>();
            InitializeComponent();
            categoryListView.ItemsSource = categories;

            AddData();
        }


        void AddData()
        {
            CategoryData _context = new CategoryData();

            foreach(var category in _context.Categories)
            {
                categories.Add(category);
            }
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var selectedCategory = e.SelectedItem as Category;
            Navigation.PushAsync(new CategoryDetailPage(selectedCategory));
        }
    }
}
