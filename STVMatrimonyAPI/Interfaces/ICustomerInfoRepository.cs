using STVMatrimony.Models;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Interfaces
{
   public interface ICustomerInfoRepository
    {
        Task<int> InsertUpdateCustomerPhotos(Photos request);
        Task<Photos> GetCustomerPhotosByCustomerId(int CustomerId);
        Task<int> InsertUpdateCustomerPreference(Preferences request);
        Task<Preferences> GetCustomerPreferenceByCustomerId(int CustomerId);
    }
}
