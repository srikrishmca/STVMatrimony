using STVMatrimony.Views;
using System;
using Xamarin.Forms;
using System.Threading.Tasks;
namespace STVMatrimony
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
            var LoginUserId=DependencyService.Get<Interface.IUserPreferences>().GetValue("LoginUserId");
            if (!string.IsNullOrEmpty(LoginUserId))
            {
                Task.Run(async () => { await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}"); });
            }
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            DependencyService.Get<Interface.IUserPreferences>().ClearPreferencesValueAndKey();
            await Current.GoToAsync("//LoginPage");
        }
    }
}
