using STVMatrimony.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace STVMatrimony.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            this.BindingContext = BootStrap.AppContainer.Resolve<RegisterViewModel>();
        }
    }
}