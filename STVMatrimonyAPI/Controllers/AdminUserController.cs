﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STVMatrimonyAPI.Interfaces;
using STVMatrimony.Models;
using STVMatrimony.Models.APIRequest;
using STVMatrimony.Utility;
using Microsoft.Extensions.Options;
using System.Web;

namespace STVMatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        public IUserDetailsRepository _Repository;
        private readonly IOptions<Model.APIConfiguration> _apiConfiguration;
        private readonly IMailService _mailService;
      

        public UserDetailsController(IUserDetailsRepository adminRepository,IOptions<Model.APIConfiguration> apiConfig,IMailService mailService)
        {
            _Repository = adminRepository;
            _apiConfiguration = apiConfig;
            _mailService = mailService;

        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUserDetails(UserDetails request)
        {

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                request.Password = Helper.EncryptString(_apiConfiguration.Value.STVEncryptionKey, request.Password);
            }
            var result = await _Repository.InsertUserDetails(request);
            if (result > 0)
            {
                Model.MailRequest mailRequest = new Model.MailRequest()
                {
                    ToEmail = request.Email,
                    Subject = "Your account has been created!",

                };
                string strURL = HttpUtility.UrlEncode(Helper.EncryptString(_apiConfiguration.Value.STVEncryptionKey, result.ToString()));
                string strUserVerfication = _apiConfiguration.Value.STVHost + "UserDetails/Verify?t=" + strURL;
                mailRequest.Body = "<h2>Your account has been created!</h2>" +
                    "<h4>Congratulations and welcome to STVMatrimony<h4>" +
                    "<a href='" + strUserVerfication + "'>Verify this email address </a>";
                await _mailService.SendRegisterEmailAsync(mailRequest);
                return Ok(result);
            }
            else
            {
                return Ok(result);
            }
            
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Verify(string t)
        {
            string strUserId= Helper.DecryptString(_apiConfiguration.Value.STVEncryptionKey, t);
            int UserId = Convert.ToInt32(strUserId);
            //ToDo : Need to check its already verified.
            var result = await _Repository.Verify(UserId);
            if (result)
            {
              
                return Ok(new AutoWrapper.Wrappers.ApiResponse("Congratulations now your account is verified"));
            }
            else
            {
                return Ok(new AutoWrapper.Wrappers.ApiResponse("Please contact STVMatrimony Admin"));
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> CheckEmailExists(string EmailId)
        {
            return Ok(await _Repository.CheckEmailExists(EmailId));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> CheckUserNameExists(string UserName)
        {
            return Ok(await _Repository.CheckUserNameExists(UserName));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateUserDetails(UserDetails request)
        {

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                request.Password = Helper.EncryptString(_apiConfiguration.Value.STVEncryptionKey, request.Password);
            }
            return Ok(await _Repository.InsertUpdateUserDetails(request));
        }


        [HttpPost("[action]")]

        public async Task<IActionResult> AuthenticateUserDetails(AuthenticateUserDetailsRequest request)
        {
            if (!string.IsNullOrEmpty(request.UserName))
            {
                var user = await _Repository.GetUserAdmin(request);
                if (user != null)
                {
                    if (!string.IsNullOrWhiteSpace(request.Password))
                    {
                        request.Password = Helper.EncryptString(_apiConfiguration.Value.STVEncryptionKey, request.Password);
                    }
                    return Ok(await _Repository.AuthenticateUserDetails(request));
                }
                else
                {
                    return Ok("Username not found.");
                }
            }
            else
            {
                return Ok("Invalid username or password");
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUserDetailss()
        {
            return Ok(await _Repository.GetAllUserDetailss());
        }

        /*[HttpGet("[action]")]
        public async Task<IActionResult> SendEmailTest()
        {
            Model.MailRequest mailRequest = new Model.MailRequest()
            {
                ToEmail = "stvmatrimony@gmail.com",
                Subject = "Your account has been created!",

            };
            mailRequest.Body = "<h2>Your account has been created!</h2>" +
                "<h4>Congratulations and welcome to STVMatrimony<h4>" +
                "<a href='" + string.Empty + "'Verify this email address </a>";
            // Message display in Mobile app  
            //"Welcome to STVMatrimony! Your account is ready,but there is one last step: please validate that you are indeed the owner of " + request.Email + " using the link in the email you received after signup. If you don't verify your email address, the account might get disabled after some time. ";


            await _mailService.SendRegisterEmailAsync(mailRequest);
            return Ok("Email sent");
        }*/
    }
}
