using STVMatrimony.Helpers.Validations;
using STVMatrimony.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace STVMatrimony.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Properties

        public ValidatableObject<string> Email { get; set; }
        public ValidatableObject<string> Password { get; set; }

        #endregion

        #region Commands

        public ICommand MyCommand { get; set; }
       
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
        public RegisterViewModel()
        {

            MyCommand = new Command<string>(MyCommandHandler);
          
            ValidateCommand = new Command<string>(ValidateCommandHandler);
            AddValidations();
        }
        private async void MyCommandHandler(string obj)
        {
            if (obj.Equals("Register"))
            {
                await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
            }
            else if (obj.Equals("Cancel"))
            {
                await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
            }
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
