using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using STVMatrimonyAPI.Interfaces;
using STVMatrimony.Models;
using STVMatrimony.Models.APIRequest;

namespace STVMatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateAdmin(Admin request)
        {
            return Ok(await _adminRepository.InsertUpdateAdmin(request));
        }


        [HttpPost("[action]")]

        public async Task<IActionResult> AuthenticateUserDetails(AuthenticateUserDetailsRequest request)
        {
            return Ok(await _adminRepository.AuthenticateUserDetails(request));
        }
    }
}
