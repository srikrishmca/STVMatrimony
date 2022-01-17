using STVMatrimony.ViewModels;
using STVMatrimony.BootStrap;
using System.ComponentModel;
using Xamarin.Forms;

namespace STVMatrimony.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = AppContainer.Resolve<ItemDetailViewModel>();
        }
    }
}