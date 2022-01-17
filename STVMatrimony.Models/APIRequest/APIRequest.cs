using System;
using System.Collections.Generic;
using System.Text;

namespace STVMatrimony.Models.APIRequest
{
    public class AuthenticateUserDetailsRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
