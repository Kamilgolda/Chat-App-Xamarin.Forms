using Plugin.Media;
using Plugin.Media.Abstractions;
using Projekt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Projekt.ViewModels
{
    class EditViewModel:BaseViewModel
    {
        public Users _zalogowany { get; set; }
        public ICommand AddImageFromGalleryCommand { get; set; }
        public ICommand AddImageCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        //private ImageSource image;
       // public ImageSource Image { get { return image; } set { image = value; OnPropertyChanged(); } }


        public EditViewModel()
        {
            Title = "Edycja profilu";
             _zalogowany = new Users();
            _zalogowany.Image =zalogowany.Image;
            _zalogowany.Name = zalogowany.Name;
            _zalogowany.LastName =zalogowany.LastName;
            _zalogowany.Email = zalogowany.Email;
            _zalogowany.Dateofbirth =zalogowany.Dateofbirth;
            _zalogowany.ImageSource = zalogowany.ImageSource;
            AddImageFromGalleryCommand = new Command(async () => await ExecuteAddImageFromGalleryCommand());
            AddImageCommand = new Command(async () => await ExecuteAddImageCommand());
            
           

        }

        async Task ExecuteAddImageFromGalleryCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
               // DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            var mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Medium
            };
            var file = await CrossMedia.Current.PickPhotoAsync(mediaOptions);

            if (file == null)
            {
               // await DisplayAlert("Error", "Nie wybrałeś zdjęcia", "Ok");
                return;
            }


            // await DisplayAlert("File Location", file.Path, "OK");

            byte[] imgdata;

            //Image = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    return stream;
            //});

            // imgdata = System.IO.File.ReadAllBytes(file.Path) ;
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                imgdata = memoryStream.ToArray();
            }

            _zalogowany.Image = imgdata;
            zalogowany.Image = imgdata;

            _zalogowany.ImageSource = ImageSource.FromStream(() => new MemoryStream(_zalogowany.Image));
        }

        async Task ExecuteAddImageCommand()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
               // DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null)
                return;

            //await DisplayAlert("File Location", file.Path, "OK");
            byte[] imgdata;

            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                imgdata = memoryStream.ToArray();
            }

            _zalogowany.Image = imgdata;

            _zalogowany.ImageSource = ImageSource.FromStream(() => new MemoryStream(_zalogowany.Image));
        }



        }
}
