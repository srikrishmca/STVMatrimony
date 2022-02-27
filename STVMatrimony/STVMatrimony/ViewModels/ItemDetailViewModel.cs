using STVMatrimony.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace STVMatrimony.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private VwCustomerBasicInfo _SelectedCustomer;
       
        public VwCustomerBasicInfo SelectedCustomer
        {
            get => _SelectedCustomer;
            set => SetProperty(ref _SelectedCustomer, value);
        }
        private int _Id;
        public int Id
        {
            get
            {
                return _Id; ;
            }
            set
            {
                _Id = value;
                LoadItemId(Id);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                VwCustomerBasicInfo item = await DataStore.GetItemAsync(itemId);
                SelectedCustomer = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
