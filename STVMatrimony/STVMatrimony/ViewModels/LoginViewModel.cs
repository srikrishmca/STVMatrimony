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
        public ICommand RegisterCommand { get; set; }
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
            RegisterCommand = new Command(RegisterCommandHandler);
            ValidateCommand = new Command<string>(ValidateCommandHandler);
            AddValidations();
        }    
        private async void RegisterCommandHandler(object obj)
        {
            Email.IsValid = true;
            Password.IsValid = true;
            await Shell.Current.GoToAsync($"/{nameof(RegisterPage)}");
        }
        private async void LoginCommandHandler(object obj)
        {
            await Helpers.Controls.CommonMethod.ShowLoading();
            #region Validation code 
            Email.IsFirstTime = false;
            Email.Validate();
            Password.IsFirstTime = false;
            Password.Validate();
            #endregion
            if (ValidateLogin())
            {
                try
                {

                    await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
                }
                catch (System.Exception ex)
                {
                    await Helpers.Controls.CommonMethod.HideLoading();
                    await DisplayAlert(ex.Message);
                }
                finally
                {
                    await Helpers.Controls.CommonMethod.HideLoading();
                }
            }
            else
            {
                await Helpers.Controls.CommonMethod.HideLoading();
            }
        }
        private async System.Threading.Tasks.Task DisplayAlert(string Message)
        {
            await Shell.Current.DisplayAlert("STVMatrimony", Message, "OK");
        }
        private bool ValidateLogin()
        {
            if (Email.IsValid == false || Password.IsValid == false)
            {
                return false;
            }
            else
            {
                return true;
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

