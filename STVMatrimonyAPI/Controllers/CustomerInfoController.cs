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
        public async Task<IActionResult> InsertUpdateCustomerPhotos(Photos request)
        {
            return Ok(await _Repository.InsertUpdateCustomerPhotos(request));
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateCustomerPreference(Preferences request)
        {
            return Ok(await _Repository.InsertUpdateCustomerPreference(request));
        }

    }
}
