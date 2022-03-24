using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Models
{
    public partial class UserdetailsActivation
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? AllowedProfileCount { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? Updatedby { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
