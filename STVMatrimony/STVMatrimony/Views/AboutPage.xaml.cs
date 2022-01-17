using STVMatrimony.ViewModels;
using Xamarin.Forms;

namespace STVMatrimony.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = BootStrap.AppContainer.Resolve<AboutViewModel>();
        }
    }
}