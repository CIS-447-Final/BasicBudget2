using System;
using System.Collections.Generic;
using BasicBudget.Models.OCR;
using Xamarin.Forms;

namespace BasicBudget
{
    public partial class CameraPage : ContentPage
    {
        public CameraPage()
        {
            InitializeComponent();

            CameraButton.Clicked += CameraButton_Clicked;

        }

       
        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { CompressionQuality = 50 });

            decimal receiptTotal = OCRProgram.TextExtraction(photo.GetStream());

            //if (photo != null)
                //PhotoImage.Source = ImageSource.FromStream(() => { return photo.GetStream(); });

        }

    }
}
