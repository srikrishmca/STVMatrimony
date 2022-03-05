using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STVMatrimony.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   // [QueryProperty(nameof(ResultText), nameof(ResultText))]
    public partial class RegisterSucessPage : ContentPage
    {
        string _ResultText = "";
        public string ResultText
        {
            get => ResultText;
            set
            {
                _ResultText = Uri.UnescapeDataString(value ?? string.Empty);
                OnPropertyChanged();
            }
        }
        public RegisterSucessPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
       

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }
    }
}