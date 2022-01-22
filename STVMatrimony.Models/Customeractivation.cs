using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Models
{
    public partial class Customeractivation
    {
        public int? Id { get; set; }
        public int? Custid { get; set; }
        public int? Remainingprofiles { get; set; }
        public bool? Isblocked { get; set; }
        public DateTime? Updatedtime { get; set; }
        public int? Updatedby { get; set; }
    }
}
