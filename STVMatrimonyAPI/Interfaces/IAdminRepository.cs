using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STVMatrimony.Models;
using STVMatrimony.Models.APIRequest;

namespace STVMatrimonyAPI.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> InsertUserDetails(UserDetails request);
        Task<int> InsertUpdateUserDetails(UserDetails request);
        Task<IEnumerable<UserDetails>> GetAllUserDetailss();
       
        Task<bool> CheckEmailExists(string EmailId);
        Task<bool> CheckUserNameExists(string UserName);
    }
}
