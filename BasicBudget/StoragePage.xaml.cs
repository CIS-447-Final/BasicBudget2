using Xamarin.Forms;
using BasicBudget.Models;



namespace BasicBudget
{
    public partial class StoragePage : ContentPage
    {
        public StoragePage()
        {
            InitializeComponent();
        }

        void Upload_Clicked(object sender, System.EventArgs e)
        {
            DatabaseConnection.Upload();

        }

        void Download_Clicked(object sender, System.EventArgs e)
        {
            DatabaseConnection.Download();
            Navigation.PopAsync();
            //ShowDownloadData();

        }

        void GetGUID(object sender, System.EventArgs e)
        {
            GUID.Text = LocalStorage.GetGUID();
        }

        void SaveGUID(object sender, System.EventArgs e)
        {
            LocalStorage.SaveGUID(GUIDTextField.Text);
        }
    }
}
