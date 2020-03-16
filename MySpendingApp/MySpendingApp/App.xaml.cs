using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySpendingApp
{
    public partial class App : Application
    {
        public static string Folderpath { get; set; }
        public App()
        {
            InitializeComponent();
            Folderpath = Environment.GetFolderPath
               (Environment.SpecialFolder.LocalApplicationData);
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromHex("#151515"),
                BarTextColor = Color.Beige
            };
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
