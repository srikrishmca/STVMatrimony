using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace STVMatrimony.Services.DBModels
{
    public partial class Preferences
    {
        public int Id { get; set; }
        public string Subcaste { get; set; }
        public int? Agemin { get; set; }
        public int? Agemax { get; set; }
        public string Diet { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Maritialstatus { get; set; }
        public string Complexion { get; set; }
        public int CustomerId { get; set; }
    }
}
