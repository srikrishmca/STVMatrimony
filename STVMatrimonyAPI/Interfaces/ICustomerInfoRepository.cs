using STVMatrimony.Models;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Interfaces
{
   public interface ICustomerInfoRepository
    {
        Task<int> InsertUpdateCustomerPhotos(Photos request);
        Task<int> InsertUpdateCustomerPreference(Preferences request);
    }
}
