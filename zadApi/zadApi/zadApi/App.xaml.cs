using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using zadApi.Models;
using zadApi.Services;
using zadApi.Views;

namespace zadApi
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static string AzureBackendUrl =
            DeviceInfo.Platform == DevicePlatform.Android ? "https://192.168.100.7:45455" : "http://localhost:44300";
        public static string CovidUrl = "https://corona-virus-stats.herokuapp.com";
        public static bool UseMockDataStore = false;

        public App()
        {
            InitializeComponent();

            if (UseMockDataStore)
            {
                DependencyService.Register<StudentDataStore>();
                DependencyService.Register<ZdjeciaDataStore>();
            }
            else
            {
                DependencyService.Register<IDataStore<Student>, StudentDataStore>();
                DependencyService.Register<IDataStore<Zdjęcia>, ZdjeciaDataStore>();
                DependencyService.Register<IDataStore<Rows>, CovidDataStore>();
                //     DependencyService.Register<IDataStore<item>,StudentDataStore>();
            }
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
