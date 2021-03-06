using STVMatrimony.APIModels;
using STVMatrimony.Services.DBModels;
using STVMatrimony.Helpers.Validations;
using STVMatrimony.Services;
using STVMatrimony.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace STVMatrimony.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        #region Properties
        public ValidatableObject<string> UserName { get; set; }
        public ValidatableObject<string> Email { get; set; }
        public ValidatableObject<string> Password { get; set; }
        public ValidatableObject<string> MobileNumber { get; set; }

        private bool _IsRegistrationDone;
        public bool IsRegistrationDone
        {
            get => _IsRegistrationDone;
            set => SetProperty(ref _IsRegistrationDone, value);
        }
        private string _ResultText;
        public string ResultText
        {
            get => _ResultText;
            set => SetProperty(ref _ResultText, value);
        }
        #endregion

        #region Commands

        public ICommand MyCommand { get; set; }
       
        public ICommand ValidateCommand { get; set; }

        #endregion

        private void AddValidations()
        {
            UserName = new ValidatableObject<string>();
            Email = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();
            MobileNumber = new ValidatableObject<string>();
            UserName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "UserName is required." });
            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A email is required." });
            Email.Validations.Add(new IsEmailRule<string> { ValidationMessage = "Email format is not correct" });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A password is required." });
            MobileNumber.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Mobile number is required." });
        }
        public RegisterViewModel()
        {
            IsRegistrationDone = false;
         
            ResultText = string.Empty;
            MyCommand = new Command<string>(MyCommandHandler);
            ValidateCommand = new Command<string>(ValidateCommandHandler);
            AddValidations();
        }

        private bool ValidateRegister()
        {
            return Email.IsValid && Password.IsValid != false && UserName.IsValid && MobileNumber.IsValid;
        }
        private async System.Threading.Tasks.Task DisplayAlert(string Message)
        {
            await Shell.Current.DisplayAlert("STVMatrimony", Message, "OK");
        }
        private async void MyCommandHandler(string obj)
        {
            if (obj.Equals("Register"))
            {
                await Helpers.Controls.CommonMethod.ShowLoading();
                #region Validation code 
                Email.IsFirstTime = false;
                Email.Validate();
                UserName.IsFirstTime = false;
                UserName.Validate();
                Password.IsFirstTime = false;
                Password.Validate();
                MobileNumber.IsFirstTime = false;
                MobileNumber.Validate();
                #endregion
                
                try
                {
                
                    if (ValidateRegister())
                    {
                        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                        {
                            ApiResponse<bool> checkEmail = await CommonService.Instance.GetResponseAsync<bool>(ServiceConstants.CheckEmailExistsRequest + Email.Value);
                            if (checkEmail.Result)
                            {
                                await Helpers.Controls.CommonMethod.HideLoading();
                                await DisplayAlert("Email already exists!");
                                return;
                            }
                            ApiResponse<bool> checkUserName = await CommonService.Instance.GetResponseAsync<bool>(ServiceConstants.CheckUserNameExistsRequest + UserName.Value);
                            if (checkUserName.Result)
                            {
                                await Helpers.Controls.CommonMethod.HideLoading();
                                await DisplayAlert("UserName already exists!");
                            }
                            else
                            {
                                UserDetails adminUser = new UserDetails()
                                {
                                    Email = Email.Value,
                                    Password = Password.Value,
                                    Username = UserName.Value,
                                    MobileNumber = MobileNumber.Value,
                                    UserId = 0,
                                    UserRoleId = 2, // Standard User
                                };
                                ApiResponse<int> result = await CommonService.Instance.PostResponseAsync<int, UserDetails>(ServiceConstants.InsertUserDetails, adminUser);
                                if (result != null)
                                {
                                    IsRegistrationDone = true;
                                    string strResult = "Your account is ready,but there is one last step: please validate that you are indeed the owner of " + Email.Value + " using the link in the email you received after signup. If you don't verify your email address, the account might get disabled after some time. ";
                                    ResultText = strResult;
                                }
                            }
                        }
                        else
                        {
                            await Helpers.Controls.CommonMethod.HideLoading();
                            await DisplayAlert("Please check your network connection.");
                        }
                    }
                    else
                    {
                        await Helpers.Controls.CommonMethod.HideLoading();
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
                case "username": UserName.Validate(); break;
            }
        }
    }
}
