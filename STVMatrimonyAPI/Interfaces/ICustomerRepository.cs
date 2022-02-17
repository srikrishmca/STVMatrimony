using STVMatrimony.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace STVMatrimonyAPI.Interfaces
{
    public interface ICustomerRepository
    {
        Task<int> InsertUpdateCustomer(Customer request);
        Task<IEnumerable<VwCustomerBasicInfo>> GetAllCustomerBasicInfo();
    }
}
