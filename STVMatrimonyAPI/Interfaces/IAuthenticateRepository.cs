using STVMatrimony.Models;
using STVMatrimony.Models.APIRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Interfaces
{
    public interface IAuthenticateRepository
    {
        Task<string> AuthenticateUserDetails(AuthenticateUserDetailsRequest request);
        Task<UserDetails> GetUserAdmin(AuthenticateUserDetailsRequest request);
        Task<bool> Verify(int UserId);
    }
}
