using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Models
{
    public partial class VwBasicProfileDetailsInfo
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Caste { get; set; }
        public string Education { get; set; }
        public DateTime? Dob { get; set; }
        public string Birthplace { get; set; }
        public string Pic1 { get; set; }
        public int Id { get; set; }
    }
}
