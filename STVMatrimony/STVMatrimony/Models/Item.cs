using System;

namespace STVMatrimony.Models
{
    public class VwCustomerBasicInfo
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