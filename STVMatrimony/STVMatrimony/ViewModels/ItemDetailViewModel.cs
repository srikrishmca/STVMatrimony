
using STVMatrimony.APIModels;
using STVMatrimony.Services;
using STVMatrimony.Services.DBModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace STVMatrimony.ViewModels
{
    [QueryProperty(nameof(Id), nameof(Id))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private VwDetailProfileInfo _SelectedCustomer;
       
        public VwDetailProfileInfo SelectedCustomer
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
                var LoginUserId = DependencyService.Get<Interface.IUserPreferences>().GetValue("LoginUserId");
                ApiResponse<VwDetailProfileInfo> result = await CommonService.Instance.GetResponseAsync<VwDetailProfileInfo>
                  (ServiceConstants.GetDetailPrfoileView + itemId + "&UserId="+ LoginUserId);


                if (result.Result != null)
                {

                    SelectedCustomer = result.Result;
                }
                else
                {

                }
                //SelectedCustomer = item;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
