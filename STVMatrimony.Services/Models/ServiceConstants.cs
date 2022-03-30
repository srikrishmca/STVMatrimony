using System;
using System.Collections.Generic;
using System.Text;

namespace STVMatrimony.APIModels
{
    public class ServiceConstants
    {
        // Live API 
       public static string ApiBaseURL = "https://stvm.onlinearasan.com/api/";
        // local API 
       // public static string ApiBaseURL = "http://192.168.15.11:8850/api/";


        public static string GetAllCustomerBasicInfo = "Customer/GetAllCustomerBasicInfo";
        public static string AuthenticateUserDetails = "Authenticate/AuthenticateUserDetails";
        public static string CheckEmailExistsRequest = "Admin/CheckEmailExists?EmailId=";
        public static string CheckUserNameExistsRequest = "Admin/CheckUserNameExists?UserName=";
        public static string InsertUserDetails = "Admin/InsertUserDetails";
        public static string GetAllBasicProfiles = "Profile/GetAllBasicProfiles";
        public static string GetDetailPrfoileView = "Profile/GetDetailProfileViewbyId?ProfileId=";
        //Profile/GetDetailProfileViewbyId?ProfileId=2&UserId=1
    }
}
