using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Models
{
    public partial class VwCustomerBasicInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int? Age { get; set; }
        public string Education { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
    }
}
