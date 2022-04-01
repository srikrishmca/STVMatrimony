
using STVMatrimony.APIModels;
using STVMatrimony.Services;
using STVMatrimony.Services.DBModels;
using STVMatrimony.Services.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Essentials;
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
        private ObservableCollection<ProfilePic> _LstProfilePics;

        public ObservableCollection<ProfilePic> LstProfilePics
        {
            get => _LstProfilePics;
            set => SetProperty(ref _LstProfilePics, value);
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
                if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                {
                    var LoginUserId = DependencyService.Get<Interface.IUserPreferences>().GetValue("LoginUserId");
                    ApiResponse<VwDetailProfileInfo> result = await CommonService.Instance.GetResponseAsync<VwDetailProfileInfo>
                      (ServiceConstants.GetDetailPrfoileView + itemId + "&UserId=" + LoginUserId);


                    if (result.Result != null)
                    {
                        LstProfilePics = new ObservableCollection<ProfilePic>();

                        SelectedCustomer = result.Result;
                        if (!string.IsNullOrWhiteSpace(SelectedCustomer.Pic1))
                        {
                            LstProfilePics.Add(new ProfilePic() { ImageURL = SelectedCustomer.Pic1 });
                        }
                        if (!string.IsNullOrWhiteSpace(SelectedCustomer.Pic2))
                        {
                            LstProfilePics.Add(new ProfilePic() { ImageURL = SelectedCustomer.Pic2 });
                        }
                        if (!string.IsNullOrWhiteSpace(SelectedCustomer.Pic3))
                        {
                            LstProfilePics.Add(new ProfilePic() { ImageURL = SelectedCustomer.Pic3 });
                        }

                    }
                    else
                    {

                    }
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
            finally
            {
                await Helpers.Controls.CommonMethod.HideLoading();
            }
        }
    }

    
}
