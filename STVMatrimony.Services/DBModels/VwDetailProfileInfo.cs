using System;


namespace STVMatrimony.Services.DBModels
{
    public partial class VwDetailProfileInfo
    {
        public int ProfileId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Caste { get; set; }
        public string Education { get; set; }
        public string Jobdetails { get; set; }
        public string Salary { get; set; }
        public DateTime? Dob { get; set; }
        public string Star { get; set; }
        public string Birthplace { get; set; }
        public string Height { get; set; }
        public string Color { get; set; }
        public string Foodstyle { get; set; }
        public string Familydetails { get; set; }
        public string Assetdetails { get; set; }
        public string Exception { get; set; }
        public bool? IsActive { get; set; }
        public string Pic1 { get; set; }
        public string Pic2 { get; set; }
        public string Pic3 { get; set; }
        public string Raasi { get; set; }
        public string Navamsam { get; set; }
    }
}
