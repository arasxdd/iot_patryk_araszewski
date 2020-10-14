using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabDTO.Models;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace Lab
{
    public partial class MainPage : ContentPage
    {
        private Person person = new Person();

        public MainPage()
        {
            InitializeComponent();
            InitializeEvents();
        }

        private void InitializeEvents()
        {

            btnCamera.Clicked += async (object sender, EventArgs e) =>
            {
                bool hasPermission = false;
                try
                {
                    await CrossMedia.Current.Initialize();
                    hasPermission = CrossMedia.Current.IsCameraAvailable;
                }
                catch (Exception genEx)
                {
                    var Error = genEx;
                }

                if (!hasPermission)
                {
                    await DisplayAlert("Błąd", "Robienie zdjęć nie jest wspierane", "OK");
                    return;
                }

                var photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions {
                    AllowCropping = true
                });

                if (photo != null)
                {
                    ImgPhoto.Source = ImageSource.FromStream(() => photo.GetStream());
                    byte[] bytes;

                    using (var memoryStream = new MemoryStream())
                    {
                        photo.GetStream().CopyTo(memoryStream);
                        bytes = memoryStream.ToArray();
                    }

                    string imgBase64 = Convert.ToBase64String(bytes);
                    person.ImgBase64 = imgBase64;
                }
            };

            entFirstName.TextChanged += (object sender, TextChangedEventArgs e) => {
                person.FirstName = e.NewTextValue;
            };
            entLastname.TextChanged += (object sender, TextChangedEventArgs e) => {
                person.LastName = e.NewTextValue;
            };
            entPhoneNr.TextChanged += (object sender, TextChangedEventArgs e) => {
                person.PhoneNumber = e.NewTextValue;
            };
        }


    }
}
