using Microsoft.AspNetCore.Mvc;
using STVMatrimony.APIModels;
using STVMatrimony.Models;
using STVMatrimony.Services;
using STVMatrimony.Services.Models;
using System.Threading.Tasks;

namespace STVMatrimonyWeb.Areas.Admin.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult InsertProfile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertProfile(ProfileDetails profile)
        {
            try
            {                

                ApiResponse<int> result = await CommonService.Instance.PostResponseAsync<int, ProfileDetails>
                    (ServiceConstants.InsertUpdateProfileDetails, profile);
                if (result! = null)
                {
                    if (result.Result > 0)
                    {
                        return View();
                    }
                }
                
                
                return View();

            }
            catch (System.Exception ex)
            {
                Task.FromException(ex.InnerException);
                return View();
            }
        }
    }
}
