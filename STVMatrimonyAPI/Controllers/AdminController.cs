using Microsoft.AspNetCore.Http;
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
    //[Filters.APIKeyAuth]
    public class AdminController: ControllerBase
    {
        public IAdminRepository _Repository;
        private readonly IOptions<Model.APIConfiguration> _apiConfiguration;
        private readonly IMailService _mailService;
      

        public AdminController(IAdminRepository adminRepository,IOptions<Model.APIConfiguration> apiConfig,IMailService mailService)
        {
            _Repository = adminRepository;
            _apiConfiguration = apiConfig;
            _mailService = mailService;

        }
        #region Userdetails codes start here 

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
                string strUserVerfication = _apiConfiguration.Value.STVHost + "Authenticate​/Verify?t=" + strURL;
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


       
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUserDetailss()
        {
            return Ok(await _Repository.GetAllUserDetailss());
        }
        #endregion
        #region Role Master
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllRoles()
        {
            return Ok(await _Repository.GetAllRoles());
        }
        #endregion

    }
}
