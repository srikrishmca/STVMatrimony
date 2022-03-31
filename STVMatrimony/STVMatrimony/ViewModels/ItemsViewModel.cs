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

        public ItemsViewModel()
        {
            Title = "MATRIMONY";
            ItemTapped = new Command<VwBasicProfileDetailsInfo>(OnItemSelected);
            Items = new ObservableCollection<VwBasicProfileDetailsInfo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadLocalItemsCommand());
        }

        async Task ExecuteLoadLocalItemsCommand()
        {
            IsBusy = true;

            try
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

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
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