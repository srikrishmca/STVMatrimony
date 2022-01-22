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
    public class AdminController : ControllerBase
    {
        public IAdminRepository _adminRepository;
        private readonly IOptions<Model.APIConfiguration> _apiConfiguration;
       
        public AdminController(IAdminRepository adminRepository,IOptions<Model.APIConfiguration> apiConfig)
        {
            _adminRepository = adminRepository;
            _apiConfiguration = apiConfig;

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateAdmin(Admin request)
        {

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                request.Password = Helper.EncryptString(_apiConfiguration.Value.STVEncryptionKey, request.Password);
            }
            return Ok(await _adminRepository.InsertUpdateAdmin(request));
        }


        [HttpPost("[action]")]

        public async Task<IActionResult> AuthenticateUserDetails(AuthenticateUserDetailsRequest request)
        {

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                request.Password = Helper.EncryptString(_apiConfiguration.Value.STVEncryptionKey, request.Password);
            }
            return Ok(await _adminRepository.AuthenticateUserDetails(request));
        }
    }
}
