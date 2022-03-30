using STVMatrimony.Services;
using STVMatrimony.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STVMatrimony
{
    public partial class App : Application
    {
      
        public App()
        {
            InitializeComponent();
            BootStrap.AppContainer.RegisterDependencies();
            MainPage = new AppShell();
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
