using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STVMatrimony.Models;
using STVMatrimonyAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Filters.APIKeyAuth]
    public class ProfileController : ControllerBase
    {
        public IProfileRepository _repository;
        public ProfileController(IProfileRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateProfileDetails(ProfileDetails request)
        {
            return Ok(await _repository.InsertUpdateProfileDetails(request));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateProfilePicture(ProfilePic request)
        {
            return Ok(await _repository.InsertUpdateProfilePicture(request));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAllProfiles()
        {
            return Ok(await _repository.GetAllProfiles());
        }

        #region Profile Pic logs
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateProfileLogCount(ProfileLogCount request)
        {
            return Ok(await _repository.InsertUpdateProfileLogCount(request));
        }
        #endregion
    }
}
