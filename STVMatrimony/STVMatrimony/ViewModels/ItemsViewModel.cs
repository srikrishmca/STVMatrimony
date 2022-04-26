using STVMatrimony.APIModels;
using STVMatrimony.Services;
using STVMatrimony.Services.DBModels;
using STVMatrimony.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace STVMatrimony.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private VwBasicProfileDetailsInfo _selectedItem;

        public ObservableCollection<VwBasicProfileDetailsInfo> Items { get;  }
        public Command LoadItemsCommand { get; }
        public Command<VwBasicProfileDetailsInfo> ItemTapped { get; }
        bool isEmpty = false;
        public bool IsEmpty
        {
            get { return isEmpty; }
            set { SetProperty(ref isEmpty, value); }
        }
        string errorText = string.Empty;
        public string ErrorText
        {
            get { return errorText; }
            set { SetProperty(ref errorText, value); }
        }
        public ItemsViewModel()
        {
            Title = "MATRIMONY";
            ItemTapped = new Command<VwBasicProfileDetailsInfo>(OnItemSelected);
            Items = new ObservableCollection<VwBasicProfileDetailsInfo>();
            LoadItemsCommand = new Command(ExecuteLoadLocalItemsCommand);

        }

        async void ExecuteLoadLocalItemsCommand()
        {
            IsEmpty = false;
            IsBusy = true;
            ErrorText = string.Empty;
           // await Helpers.Controls.CommonMethod.ShowLoading();
            try
            {
              
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    Items.Clear();
                    ApiResponse<IEnumerable<VwBasicProfileDetailsInfo>> result = await CommonService.Instance.GetResponseAsync<IEnumerable<VwBasicProfileDetailsInfo>>
                        (ServiceConstants.GetAllBasicProfiles);

                    if (result.Result != null)
                    {
                        foreach (VwBasicProfileDetailsInfo item in result.Result)
                        {
                            Items.Add(item);
                        }

                    }
                    else
                    {
                        ErrorText = "No data available";
                        IsEmpty = true;
                    }
                }
                else
                {
                    ErrorText = "No network connection";
                    IsEmpty = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
              //  await Helpers.Controls.CommonMethod.HideLoading();
            }
        }
        //async Task ExecuteLoadItemsCommand()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        Items.Clear();
        //        if (Connectivity.NetworkAccess == NetworkAccess.Internet)
        //        {
        //            ApiResponse<List<VwCustomerBasicInfo>> result = await CommonService.Instance.GetResponseAsync<List<VwCustomerBasicInfo>>(ServiceConstants.GetAllCustomerBasicInfo);
                
        //            if (result.Result != null)
        //            {
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine(ex);
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public VwBasicProfileDetailsInfo SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

       

        async void OnItemSelected(VwBasicProfileDetailsInfo item)
        {
            if (item == null)
            {
                return;
            }
            await Helpers.Controls.CommonMethod.ShowLoading();
            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.Id)}={item.ProfileId}");
        }
    }
}