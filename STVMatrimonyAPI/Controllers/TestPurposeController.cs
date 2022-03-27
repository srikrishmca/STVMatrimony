//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using STVMatrimony.Utility;
//using STVMatrimonyAPI.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;

//namespace STVMatrimonyAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TestPurposeController : ControllerBase
//    {
//        private readonly IOptions<Model.APIConfiguration> _apiConfiguration;
//        public TestPurposeController(IOptions<Model.APIConfiguration> apiConfig)
//        {
//            _apiConfiguration = apiConfig;
//        }
//        [HttpGet("[action]")]
//        public async Task<IActionResult> EncryptTestString(string val)
//        {
//            string strURL = _apiConfiguration.Value.STVHost + "Authenticate/Verify?t=" + HttpUtility.UrlEncode(Helper.EncryptString(_apiConfiguration.Value.STVEncryptionKey, val));
//            await Task.Delay(1);
//            return Ok(strURL);
//        }
//        [HttpGet("[action]")]
//        public async Task<IActionResult> DecryptTestString(string val)
//        {
//            string strURL = Helper.DecryptString(_apiConfiguration.Value.STVEncryptionKey, val);
//            await Task.Delay(1);
//            return Ok(strURL);
//        }
//    }
//}
