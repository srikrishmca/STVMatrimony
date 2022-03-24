using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using STVMatrimony.Models;
using STVMatrimonyAPI.Interfaces;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        public ICustomerInfoRepository _Repository;
        private readonly IOptions<Model.APIConfiguration> _apiConfiguration;

        public CustomerInfoController(ICustomerInfoRepository photosRepository, IOptions<Model.APIConfiguration> apiConfig)
        {
            _Repository = photosRepository;
            _apiConfiguration = apiConfig;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateCustomerPhotos(ProfilePic request)
        {
            return Ok(await _Repository.InsertUpdateCustomerPhotos(request));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCustomerPhotosByCustomerId(int ProfileId)
        {
            return Ok(await _Repository.GetCustomerPhotosByCustomerId(ProfileId));
        }

        

    }
}
