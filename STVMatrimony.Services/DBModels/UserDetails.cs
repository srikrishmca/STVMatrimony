using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Services.DBModels
{
    public partial class UserDetails
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }
        public int UserRoleId { get; set; }
    }
}
