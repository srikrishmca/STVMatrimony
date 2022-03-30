using STVMatrimony.APIModels;
using STVMatrimony.Helpers.Validations;
using STVMatrimony.Services;
using STVMatrimony.Services.DBModels;
using STVMatrimony.Services.Models;
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

        public ValidatableObject<string> UserName { get; set; }
        public ValidatableObject<string> Password { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }
        public ICommand ValidateCommand { get; set; }

        #endregion

        private void AddValidations()
        {
            UserName = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();

            UserName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "UserName is required." });
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
            UserName.IsValid = true;
            Password.IsValid = true;
            await Shell.Current.GoToAsync($"/{nameof(RegisterPage)}");
        }
        private async void LoginCommandHandler(object obj)
        {
            await Helpers.Controls.CommonMethod.ShowLoading();
            #region Validation code 
            UserName.IsFirstTime = false;
            UserName.Validate();
            Password.IsFirstTime = false;
            Password.Validate();
            #endregion
            if (ValidateLogin())
            {
                try
                {
                    AuthenticateUserDetailsRequest request = new AuthenticateUserDetailsRequest()
                    {
                        Password = Password.Value,
                        UserName = UserName.Value
                    };
                    ApiResponse<string> result = await CommonService.Instance.PostResponseAsync<string, AuthenticateUserDetailsRequest>
                        (ServiceConstants.AuthenticateUserDetails, request);

                    if (result.Result != null)
                    {
                        DependencyService.Get<Interface.IUserPreferences>().SetValue("LoginUserId", result.Result);
                        await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");

                    }
                    else
                    {
                        await DisplayAlert("Invalid username or password.");
                    }
                  
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
            if (UserName.IsValid == false || Password.IsValid == false)
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
                case "email": UserName.Validate(); break;
                case "password": Password.Validate(); break;
            }
        }
    }
}

