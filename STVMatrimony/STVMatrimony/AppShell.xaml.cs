using STVMatrimony.Views;
using System;
using Xamarin.Forms;

namespace STVMatrimony
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            if (!App.IsLogin)
            {
                System.Threading.Tasks.Task.Run(async() =>
                {
                    await Current.GoToAsync("//LoginPage");
                });
                
            }
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Current.GoToAsync("//LoginPage");
        }
    }
}
