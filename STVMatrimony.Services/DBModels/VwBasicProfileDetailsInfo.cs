using System;
using System.Collections.Generic;
using System.Text;

namespace STVMatrimony.Services.DBModels
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
