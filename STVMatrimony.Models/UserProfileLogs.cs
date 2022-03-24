using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Models
{
    public partial class UserProfileLogs
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ProfileId { get; set; }
        public DateTime? ViewedDate { get; set; }
    }
}
