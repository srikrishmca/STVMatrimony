using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Models
{
    public partial class ProfileDetails
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public Gender Sex { get; set; }
        public string Caste { get; set; }
        public string Education { get; set; }
        public string Jobdetails { get; set; }
        public string Salary { get; set; }
        public DateTime? Dob { get; set; }
        public string Star { get; set; }
        public string Birthplace { get; set; }
        public string Height { get; set; }
        public string Color { get; set; }
        public Food Foodstyle { get; set; }
        public string Familydetails { get; set; }
        public string Assetdetails { get; set; }
        public string Exception { get; set; }
        public bool? IsActive { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Food
    {
       Veg,
       NonVeg
    }
}
