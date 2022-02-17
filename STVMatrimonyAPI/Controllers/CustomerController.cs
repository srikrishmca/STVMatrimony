using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using STVMatrimony.Models;
using STVMatrimonyAPI.Interfaces;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ICustomerRepository _Repository;
        private readonly IOptions<Model.APIConfiguration> _apiConfiguration;

        public CustomerController(ICustomerRepository customerRepository, IOptions<Model.APIConfiguration> apiConfig)
        {
            _Repository = customerRepository;
            _apiConfiguration = apiConfig;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> InsertUpdateCustomer(Customer request)
        {
            return Ok(await _Repository.InsertUpdateCustomer(request));
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCustomerBasicInfo()
        {
            return Ok(await _Repository.GetAllCustomerBasicInfo());
        }
    }
}
