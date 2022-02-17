using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public DateTime? Dob { get; set; }
        public string Birthplace { get; set; }
        public int? Age { get; set; }
        public string Income { get; set; }
        public string Education { get; set; }
        public string Subcaste { get; set; }
        public string Bloodgroup { get; set; }
        public string Aboutme { get; set; }
        public string Assets { get; set; }
        public string Expectations { get; set; }
        public string Star { get; set; }
        public bool? IsActive { get; set; }
    }
}
