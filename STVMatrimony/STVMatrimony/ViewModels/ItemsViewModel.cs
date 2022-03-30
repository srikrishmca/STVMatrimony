using STVMatrimony.APIModels;
using STVMatrimony.Models;
using STVMatrimony.Services;
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
        private VwCustomerBasicInfo _selectedItem;

        public ObservableCollection<VwCustomerBasicInfo> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command<VwCustomerBasicInfo> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "MATRIMONY";
            ItemTapped = new Command<VwCustomerBasicInfo>(OnItemSelected);
            Items = new ObservableCollection<VwCustomerBasicInfo>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadLocalItemsCommand());
        }

        async Task ExecuteLoadLocalItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
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

        public VwCustomerBasicInfo SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

       

        async void OnItemSelected(VwCustomerBasicInfo item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.Id)}={item.Id}");
        }
    }
}