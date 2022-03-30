﻿using System;
using System.Collections.Generic;
using System.Text;

namespace STVMatrimony.APIModels
{
    public class ServiceConstants
    {
        // Live API 
        public static string ApiBaseURL = "https://stvm.onlinearasan.com/api/";
        // local API 
       // public static string ApiBaseURL = "http://192.168.188.236:8850/api/";


        public static string GetAllCustomerBasicInfo = "Customer/GetAllCustomerBasicInfo";
        public static string AuthenticateUserDetails = "Authenticate/AuthenticateUserDetails";
        public static string CheckEmailExistsRequest = "Admin/CheckEmailExists?EmailId=";
        public static string CheckUserNameExistsRequest = "Admin/CheckUserNameExists?UserName=";
        public static string InsertUserDetails = "Admin/InsertUserDetails";
    }
}
