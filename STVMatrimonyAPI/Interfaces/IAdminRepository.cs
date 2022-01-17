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
        Task<int> InsertUpdateAdmin(Admin request);
        Task<string> AuthenticateUserDetails(AuthenticateUserDetailsRequest request);
    }
}
