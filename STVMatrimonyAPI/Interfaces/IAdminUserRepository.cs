using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STVMatrimony.Models;
using STVMatrimony.Models.APIRequest;

namespace STVMatrimonyAPI.Interfaces
{
    public interface IAdminUserRepository
    {
        Task<int> InsertUpdateAdminUser(AdminUser request);
        Task<string> AuthenticateUserDetails(AuthenticateUserDetailsRequest request);
        Task<AdminUser> GetUserAdmin(AuthenticateUserDetailsRequest request);
        Task<IEnumerable<AdminUser>> GetAllAdminUsers();
    }
}
