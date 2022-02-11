using STVMatrimony.Helpers.Validations;
using STVMatrimony.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace STVMatrimony.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Properties

        public ValidatableObject<string> Email { get; set; }
        public ValidatableObject<string> Password { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }
        public ICommand ValidateCommand { get; set; }

        #endregion

        private void AddValidations()
        {
            Email = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A email is required." });
            Email.Validations.Add(new IsEmailRule<string> { ValidationMessage = "Email format is not correct" });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
        }
        public LoginViewModel()
        {

            LoginCommand = new Command(LoginCommandHandler);
            ValidateCommand = new Command<string>(ValidateCommandHandler);
            AddValidations();
        }    

        private async void LoginCommandHandler(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
        }
        private void ValidateCommandHandler(string field)
        {
            switch (field)
            {
                case "email": Email.Validate(); break;
                case "password": Password.Validate(); break;
            }
        }
    }
}

