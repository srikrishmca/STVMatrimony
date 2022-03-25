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
using Microsoft.AspNetCore.Authorization;

namespace STVMatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Filters.APIKeyAuth]
    public class AuthenticateController : ControllerBase
    {
        public IAuthenticateRepository _Repository;
        private readonly IOptions<Model.APIConfiguration> _apiConfiguration;
        public AuthenticateController(IAuthenticateRepository adminRepository, IOptions<Model.APIConfiguration> apiConfig)
        {
            _Repository = adminRepository;
            _apiConfiguration = apiConfig;
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
        [HttpPost("[action]")]

        public async Task<IActionResult> GetUserAdmin(AuthenticateUserDetailsRequest request)
        {
            return Ok(await _Repository.GetUserAdmin(request));
        }
        [HttpGet("[action]")]
        [AllowAnonymous]
        public async Task<IActionResult> Verify(string t)
        {
            string strUserId = Helper.DecryptString(_apiConfiguration.Value.STVEncryptionKey, t);
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
    }
}
