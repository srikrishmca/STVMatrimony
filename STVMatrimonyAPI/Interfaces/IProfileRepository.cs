using STVMatrimony.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Interfaces
{
    public interface IProfileRepository
    {
        #region ProfileDetails codes start here 
        Task<int> InsertUpdateProfileDetails(ProfileDetails request);
        Task<int> InsertUpdateProfilePicture(ProfilePic request);
        Task<IEnumerable<ProfileDetails>> GetAllProfiles();
        Task<IEnumerable<VwBasicProfileDetailsInfo>> GetAllBasicProfiles();
        Task<VwDetailProfileInfo> GetDetailProfileViewbyId(int ProfileId, int UserId);
        #endregion


        #region Profile Pic logs
        Task<int> InsertUpdateProfileLogCount(ProfileLogCount request);
        #endregion
    }
}
