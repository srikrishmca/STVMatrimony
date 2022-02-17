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

namespace STVMatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminUserController : ControllerBase
    {
        public IAdminUserRepository _Repository;
        private readonly IOptions<Model.APIConfiguration> _apiConfiguration;
       
        public AdminUserController(IAdminUserRepository adminRepository,IOptions<Model.APIConfiguration> apiConfig)
        {
            _Repository = adminRepository;
            _apiConfiguration = apiConfig;

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateAdminUser(AdminUser request)
        {

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                request.Password = Helper.EncryptString(_apiConfiguration.Value.STVEncryptionKey, request.Password);
            }
            return Ok(await _Repository.InsertUpdateAdminUser(request));
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
                    return Ok(NotFound("User details not found"));
                }
            }
            else
            {
                return Ok(NotFound("User details not found"));
            }
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllAdminUsers()
        {
            return Ok(await _Repository.GetAllAdminUsers());
        }
    }
}
