using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace STVMatrimony.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Application.Current.MainPage.DisplayAlert("Matrimony","Under development","OK"));
        }

        public ICommand OpenWebCommand { get; }
    }
}