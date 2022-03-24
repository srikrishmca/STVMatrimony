using STVMatrimony.Models;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Interfaces
{
   public interface ICustomerInfoRepository
    {
        Task<int> InsertUpdateCustomerPhotos(ProfilePic request);
        Task<ProfilePic> GetCustomerPhotosByCustomerId(int ProfileId);
    }
}
