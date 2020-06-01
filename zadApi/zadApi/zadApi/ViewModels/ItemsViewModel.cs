using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using zadApi.Models;
using zadApi.Views;

namespace zadApi.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Student> Items { get; set; }
        public ObservableCollection<StudentZdj> Itemks { get; set; }
        public ObservableCollection<Zdjęcia> Zdjecia { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Lista studentów";
            Items = new ObservableCollection<Student>();
            Itemks = new ObservableCollection<StudentZdj>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Student>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Student;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });

            MessagingCenter.Subscribe<ItemDetailPage, Student>(this, "UpdateItem", async (obj, item) =>
            {
                await DataStore.UpdateItemAsync(item);
            });

        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            Image image = new Image();
            image.Source = "E:/repozytorium/zadApi/zadApi/zadApi/user.jpg";
            try
            {
                Itemks.Clear();
                 var items = await DataStore.GetItemsAsync(true);
                var zdjecia = await ZdjeciaStore.GetItemsAsync(true);
                StudentZdj studentZdj;
               // byte[] imgdata = System.IO.File.ReadAllBytes("E:/repozytorium/zadApi/zadApi/zadApi/user.jpg");
                

               // byteData = System.IO.File.ReadAllBytes("E:/repozytorium/zadApi/zadApi/zadApi/user.jpg");
               
                foreach (var item in items)
                {
                    studentZdj = new StudentZdj();
                    studentZdj.Zdjęcie = image.Source.ToString();
                    foreach (var zdj in zdjecia)
                    {
                        if (zdj.IdStudent.ToString() == item.Id.ToString())
                        {

                            image.Source = ImageSource.FromStream(() => new MemoryStream(zdj.Zdjęcie));
                            studentZdj.Zdjęcie = image.Source;
                        }
                    }
                    studentZdj.Id = item.Id;
                    studentZdj.Imie = item.Imie;
                    studentZdj.Nazwisko = item.Nazwisko;
                    studentZdj.NrAlbumu = item.NrAlbumu;
                    studentZdj.Plec = item.Plec;

                    Itemks.Add(studentZdj);
                }
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            byte[] imageByteArray = null;
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                imageByteArray = new byte[reader.BaseStream.Length];
                for (int i = 0; i < reader.BaseStream.Length; i++)
                    imageByteArray[i] = reader.ReadByte();
            }
            return imageByteArray;
        }

    }
}